create database RailwayReservation

use RailwayReservation

create table Admin(
AdminId int primary key identity(1,1),
FullName varchar(30) not null, 
Password varchar(64) not null,
Email varchar(50) not null unique, 
PhoneNumber bigint not null unique,
CreatedAt datetime default getdate()
); 

create table UserTable(
UserId int primary key identity(1,1), 
FullName varchar(30) not null, 
Password varchar(64) not null,
Email varchar(50) not null unique, 
PhoneNumber bigint not null unique,
CreatedAt datetime default getdate()
); 

create table Station(
StationId int primary key identity(1,1), 
StationName varchar(50) not null unique
);

create table Train(
TrainId int primary key identity(1,1),
TrainCode numeric(6) not null unique, 
TrainName varchar(30) not null unique, 
SourceStationId int not null, 
DestinationStationId int not null,
ArrivalTime time null,
DepartureTime time not null, 
CreatedAt datetime default getdate(),
foreign key(SourceStationId) references Station(StationId),
foreign key(DestinationStationId) references Station(StationId),
);

drop table TrainRoute
create table TrainRoute(
RouteId int primary key identity(1,1),
TrainId int not null,
StationId int not null,
RouteOrder int not null,
ArrivalTime time not null,
DepartureTime time not null,
foreign key(TrainId) references Train(TrainId),
foreign key(StationId) references Station(StationId)
);

drop Table Train

drop Table TrainRoute
drop table TrainRunningDays
drop Table FareDetails
drop Table Seats

create table TrainRunningDays(
TrainId int,
DayOfWeek int,
foreign key(TrainId) references Train(TrainId),
Primary key(TrainId,DayOfWeek)
);


create table FareDetails(
FareId int primary key identity(1,1),
TrainId int not null,
FromStationId int not null,
ToStationId int not null,
Class varchar(30) not null,
FareAmount float not null,
foreign key(TrainId) references Train(TrainId),
foreign key(FromStationId) references Station(StationId),
foreign key(ToStationId) references Station(StationId),
unique(TrainId,FromStationId,ToStationId,Class)
);


create table Seats(
SeatId int primary key identity(1,1),
TrainId int not null,
Class varchar(30) not null,
TotalSeats int not null,
AvailableSeats int not null,
CoachCount int not null,
foreign key(TrainId) references Train(TrainId),
unique(TrainId,Class)
);


create table Reservation(
ReservationId int primary key identity(1,1),
TrainId int not null,
UserId int not null,
SourceStationId int not null,
DestinationStationId int not null,
JourneyDate date not null,
BookingDate datetime not null default getdate(),
PassengerCount int not null check(PassengerCount between 1 and 6),
Status varchar(50) not null,
foreign key(TrainId) references Train(TrainId),
foreign key(UserId) references UserTable(UserId),
foreign key(SourceStationId) references Station(StationId),
foreign key(DestinationStationId) references Station(StationId)
);


create table Passenger(
PassengerId int primary key identity(1,1),
ReservationId int not null,
Name varchar(50) not null,
Age int not null,
Gender varchar(10) not null,
AllottedBerth varchar(20) not null,
foreign key(ReservationId) references Reservation(ReservationId)
);

create table Payment(
PaymentId int primary key identity(1,1),
ReservationId int not null,
UPI_Id varchar(50) not null,
Amount float not null,
DateOfPayment datetime default getdate(),
foreign key(ReservationId) references Reservation(ReservationId)
);

create table Cancellation(
CancellationId int primary key identity(1,1),
ReservationId int not null,
AmountRefund float not null,
CancellationDate datetime default getdate()
);
