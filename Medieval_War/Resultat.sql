drop table if exists Resultat_;
drop table if exists Pobeda_Info;
drop table if exists Porajenie_Info;

create table Pobeda_Info
(
	Id int not null identity(1, 1) primary key,
	Vse_Soldati int not null,
	Vijivshie int not null
);

create table Porajenie_Info
(
	Id int not null identity(1, 1) primary key,
	Vse_Soldati int not null
);
create table Resultat_
(
	Id int not null identity(1, 1) primary key,
	Pobeda_Id int not null,
	Porajenie_Id int not null,
	constraint fk_Pobeda_Id foreign key (Pobeda_Id) references Pobeda_Id(Id),
	constraint fk_Porajenie_Id foreign key (Porajenie_Id) references Porajenie_Id(Id)
);

select * from Pobeda_Info;
select * from Porajenie_Info;
select * from Resultat_;