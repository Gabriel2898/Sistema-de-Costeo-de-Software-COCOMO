create database GACC_ComplexivoEstimacionDeCostos
go
use GACC_ComplexivoEstimacionDeCostos
go 
create table GACC_TblCargo(
gacc_CarId int primary key identity(1,1),
gacc_CarNombre varchar(50) not null,
gacc_CarEstado char(1) not null);

create table GACC_TblEmpresa(
gacc_EmpId int primary key identity(1,1),
gacc_EmpRuc varchar(13) unique not null,
gacc_EmpNombre varchar(100) not null,
gacc_EmpDireccion varchar(300) not null, 
gacc_EmpTelefono varchar(10) not null,
gacc_EmpCorreo varchar(200) not null,
gacc_EmpEstado char(1) not null);

create table GACC_TblPersona(
gacc_PerId int primary key identity(1,1),
gacc_PerUsuarioNombre varchar(10) not null,
gacc_PerPassword varchar(150) not null,
gacc_PerDni varchar(10) unique not null,
gacc_PerPrimerNombre varchar(50) not null,
gacc_PerSegundoNombre varchar(50) not null,
gacc_PerPrimerApellido varchar(50) not null,
gacc_PerSegundoApellido varchar(50) null,
gacc_PerGenero char(1) not null,
gacc_CodEmpId int references GACC_TblEmpresa(gacc_EmpId) not null,
gacc_CodCarId int references GACC_TblCargo(gacc_CarId) not null,
gacc_PerEspecialidad varchar(100) not null,
gacc_PerExperiencia varchar(30) not null,
gacc_PerSalario decimal(8,2) not null,
gacc_PerDireccion varchar(100) not null,
gacc_PerTelefono varchar(10) not null,
gacc_PerCorreo varchar(200) not null,
gacc_PerEstado char(1) not null);
 
create table GACC_TblNombreProyecto(
gacc_NompId int primary key identity(1,1),
gacc_CodEmpId int references GACC_TblEmpresa(gacc_EmpId) not null,
gacc_CodPerId int references GACC_TblPersona(gacc_PerId) not null,
gacc_NompNombre varchar(100) not null,
gacc_NompEstado char(1) not null);

create table GACC_TblMetodologia(
gacc_MetId int primary key identity(1,1),
gacc_CodNompId int references GACC_TblNombreProyecto(gacc_NompId) not null,
gacc_MetNombre varchar(50) not null,
gacc_CodPerId int references GACC_TblPersona(gacc_PerId) not null,
gacc_MetEstado char(1) not null);

create table GACC_TblFaseDeDesarrollo(
gacc_FasId int primary key identity(1,1),
gacc_CodMetId int references GACC_TblMetodologia(gacc_MetId) not null,
gacc_CodPerId int references GACC_TblPersona(gacc_PerId) not null,
gacc_FasNombre varchar(50) not null,
gacc_FasEstado char(1) not null);


create table GACC_TblActividad(
gacc_ActId int primary key identity(1,1),
gacc_CodFasId int references GACC_TblFaseDeDesarrollo(gacc_FasId) not null,
gacc_CodPerId int references GACC_TblPersona(gacc_PerId) not null,
gacc_ActNombre varchar(50) not null,
gacc_ActEstado char(1) not null);


create table GACC_TblTarea(
gacc_TarId int primary key identity(1,1),
gacc_CodActId int references GACC_TblActividad(gacc_ActId) not null,
gacc_CodPerId int references GACC_TblPersona(gacc_PerId) not null,
gacc_TarNombre varchar(50) not null,
gacc_TarLineaCodigo int not null,
gacc_TarFechaInicio date not null,
gacc_TarFechaFin date not null,
gacc_TarEstado char(1) not null);


create table GACC_TblProyecto(
gacc_ProId  int primary key identity(1,1),
gacc_CodEmpId int references GACC_TblEmpresa(gacc_EmpId) not null,
gacc_CodNompId int references GACC_TblNombreProyecto(gacc_NompId) not null,
gacc_ProLineasCodigo int not null,
gacc_ProLineaCodigoExistente int not null,
gacc_ProLenguaje varchar(50) not null,
gacc_ProGestorBaseDatos varchar(50) not null,
gacc_ProTipoProyecto varchar(100) not null,
gacc_ProModeloProyecto varchar(100) not null,
gacc_ProEsfuerzoNominal decimal(10,2) not null,
gacc_ProEsfuerzoAjustado decimal(10,2) not null,
gacc_ProTiempo decimal(10,2) not null,
gacc_ProFechaInicio date not null,
gacc_ProFechaFin date not null,
gacc_ProCostoTrabajadores decimal (10,2)  null,
gacc_ProCostoCostoIndirectos decimal (10,2)  null,
gacc_ProCostoTotal decimal(20,2)  null,
gacc_ProNumeroPersonas decimal(10,2) not null,
gacc_ProEstado char (1) not null);

create table GACC_TblCostoIndirecto(
gacc_CostId int primary key,
gacc_CostNombre varchar(50) not null,
gacc_CostValor decimal(8,2) not null,
gacc_CostNombreProyectoID int not null,
gacc_CostEstado char(1) not null);

create table GACC_TblProyectoTblPersona(
gacc_ProPerId  int primary key identity(1,1),
gacc_CodPerId int references GACC_TblPersona(gacc_PerId),
gacc_CodNompId int references GACC_TblNombreProyecto(gacc_NompId));

create table GACC_TblProyectoTblCostoIndirecto(
gacc_ProCostId  int primary key identity(1,1),
gacc_CodCostId int references GACC_TblCostoIndirecto(gacc_CostId),
gacc_CodNompId int references GACC_TblNombreProyecto(gacc_NompId));
--vistas 
create view GACC_ViewPersona
as
select p.gacc_PerId, gacc_PerUsuarioNombre,p.gacc_PerPassword, p.gacc_PerDni,P.gacc_PerPrimerNombre+' '+  P.gacc_PerSegundoNombre +' '+ P.gacc_PerPrimerApellido+' '+P.gacc_PerSegundoApellido as Nombres_Completos,p.gacc_PerGenero,p.gacc_CodCarId,p.gacc_CodEmpId,p.gacc_PerEspecialidad,p.gacc_PerExperiencia,p.gacc_PerSalario,p.gacc_PerDireccion,p.gacc_PerTelefono,p.gacc_PerCorreo,p.gacc_PerEstado
from GACC_TblPersona as p 
go

select * from GACC_ViewPersona

-----------------------------------------------------------
create view GACC_ViewNombreProyectoListar
as
select pR.gacc_NompId,e.gacc_EmpId,e.gacc_EmpNombre,pr.gacc_NompNombre,pr.gacc_NompEstado,p.gacc_PerPrimerNombre+' '+p.gacc_PerSegundoNombre+' '+p.gacc_PerPrimerApellido+' '+p.gacc_PerSegundoApellido as Nombres_Completos,c.gacc_CarId,p.gacc_PerEstado,p.gacc_PerId
from GACC_TblEmpresa as E inner join GACC_TblNombreProyecto as PR on PR.gacc_CodEmpId=E.gacc_EmpId
inner join GACC_TblPersona as P on PR.gacc_CodPerID=P.gacc_PerId
inner join GACC_TblCargo as c on c.gacc_CarId=p.gacc_CodCarId
go 
select * from GACC_ViewNombreProyectoListar

-----------------------------------------------------------
create view GACC_ViewNombreProyectoEmpresa
as
select pR.*,e.*, p.gacc_PerId,p.gacc_PerPrimerNombre+' '+p.gacc_PerSegundoNombre+' '+p.gacc_PerPrimerApellido+' '+p.gacc_PerSegundoApellido as Nombres_Completos,c.gacc_CarNombre,c.gacc_CarId
from GACC_TblEmpresa as E inner join GACC_TblNombreProyecto as PR on PR.gacc_CodEmpId=E.gacc_EmpId
inner join GACC_TblPersona as P on PR.gacc_CodPerID=P.gacc_PerId
inner join GACC_TblCargo as c on p.gacc_CodCarId=c.gacc_CarId
go 

select * from GACC_ViewNombreProyectoEmpresa

-----------------------------------------------------------

create view GACC_ViewPersonaCargoEmpresa 
as
select p.gacc_PerId,p.gacc_PerUsuarioNombre,p.gacc_PerPassword,p.gacc_PerDni,p.gacc_PerPrimerNombre+' '+p.gacc_PerSegundoNombre+' '+p.gacc_PerPrimerApellido+' '+p.gacc_PerSegundoApellido as Nombres_Completos,p.gacc_PerGenero,e.gacc_EmpNombre,c.gacc_CarNombre,p.gacc_PerEspecialidad,p.gacc_PerExperiencia,p.gacc_PerSalario,p.gacc_PerDireccion,p.gacc_PerTelefono,p.gacc_PerCorreo,p.gacc_PerEstado
from GACC_TblPersona as P inner join GACC_TblEmpresa as E on P.gacc_CodEmpId=E.gacc_EmpId
join GACC_TblCargo as C on P.gacc_CodCarId=C.gacc_CarId
go 

select * from GACC_ViewPersonaCargoEmpresa
------------------------------------------------------------
create view GACC_ViewPersonaCargoEmpresa2
as
select p.gacc_PerId,p.gacc_PerUsuarioNombre,p.gacc_PerPassword,p.gacc_PerDni,p.gacc_PerPrimerNombre+' '+p.gacc_PerSegundoNombre+' '+p.gacc_PerPrimerApellido+' '+p.gacc_PerSegundoApellido as Nombres_Completos,p.gacc_PerGenero,p.gacc_PerEspecialidad,p.gacc_PerExperiencia,p.gacc_PerSalario,p.gacc_PerDireccion,p.gacc_PerTelefono,p.gacc_PerCorreo,p.gacc_PerEstado, e.*,c.*
from GACC_TblPersona as P inner join GACC_TblEmpresa as E on P.gacc_CodEmpId=E.gacc_EmpId
join GACC_TblCargo as C on P.gacc_CodCarId=C.gacc_CarId
go 

select * from GACC_ViewPersonaCargoEmpresa2
------------------------------------------------------------
create view GACC_ViewMetodologiaPersonaNombreProy
as
select m.gacc_MetId, E.gacc_EmpNombre,pr.gacc_NompNombre,e.Nombres_Completos,m.gacc_MetNombre,p.gacc_PerPrimerNombre+' '+  P.gacc_PerSegundoNombre +' '+ P.gacc_PerPrimerApellido+' '+P.gacc_PerSegundoApellido as Encargado,p.gacc_PerEstado,m.gacc_MetEstado
from GACC_TblMetodologia as M inner join GACC_TblNombreProyecto as PR on PR.gacc_NompId=M.gacc_CodNompId
join GACC_ViewNombreProyectoEmpresa as E on E.gacc_NompId=m.gacc_CodNompId
join GACC_TblPersona as P on P.gacc_PerId=M.gacc_CodPerId
join GACC_TblPersona as per on per.gacc_PerId= e.gacc_CodPerId
go 

select * from GACC_ViewMetodologiaPersonaNombreProy
------------------------------------------------------------
create view GACC_ViewMetodologiaPersonaNombreProy2
as
select e.gacc_EmpId,e.gacc_EmpNombre,e.gacc_EmpEstado,pr.*,e.Nombres_Completos,m.gacc_MetId,m.gacc_MetNombre,m.gacc_MetEstado,p.gacc_PerPrimerNombre+' '+  P.gacc_PerSegundoNombre +' '+ P.gacc_PerPrimerApellido+' '+P.gacc_PerSegundoApellido as Encargado,p.gacc_PerId,p.gacc_CodCarId,p.gacc_PerEstado,c.gacc_CarId,c.gacc_CarNombre
from GACC_TblMetodologia as M inner join GACC_TblNombreProyecto as PR on PR.gacc_NompId=M.gacc_CodNompId
join GACC_TblPersona as P on P.gacc_PerId=M.gacc_CodPerId
join GACC_ViewNombreProyectoEmpresa as E on E.gacc_NompId=m.gacc_CodNompId
join GACC_TblPersona as per on per.gacc_PerId= e.gacc_CodPerId
join GACC_TblCargo as c on c.gacc_CarId=p.gacc_CodCarId
go 
select * from GACC_ViewMetodologiaPersonaNombreProy2

--------------------------------------------------------------
create view GACC_ViewMetodologiaFase
as
select f.gacc_FasId, VNPE.gacc_EmpNombre,VMPNP.gacc_NompNombre,vnpe.Nombres_Completos,m.gacc_MetNombre,VMPN.gacc_PerPrimerNombre+' '+  VMPN.gacc_PerSegundoNombre +' '+ VMPN.gacc_PerPrimerApellido+' '+VMPN.gacc_PerSegundoApellido as Encargado_Metodologia,f.gacc_FasNombre,p.gacc_PerPrimerNombre+' '+  p.gacc_PerSegundoNombre +' '+ p.gacc_PerPrimerApellido+' '+p.gacc_PerSegundoApellido as Encargado_Fase,p.gacc_PerEstado, f.gacc_FasEstado
from GACC_TblFaseDeDesarrollo as F inner join GACC_TblMetodologia as M  on M.gacc_MetId=F.gacc_CodMetId
join GACC_TblPersona as P on P.gacc_PerId= F.gacc_CodPerId 
join GACC_TblPersona AS VMPN ON VMPN.gacc_PerId=M.gacc_CodPerId 
join GACC_TblNombreProyecto AS VMPNP ON VMPNP.gacc_NompId=M.gacc_CodNompId
join GACC_ViewNombreProyectoEmpresa AS VNPE ON VNPE.gacc_NompId=m.gacc_CodNompId
join GACC_TblPersona as per on per.gacc_PerId= vnpe.gacc_CodPerId
go


select * from GACC_ViewMetodologiaFase
--------------------------------------------------------------
create view GACC_ViewMetodologiaFase2
as
select VNPE.gacc_EmpId,VNPE.gacc_EmpNombre,VNPE.gacc_EmpEstado,VMPNP.*,vnpe.Nombres_Completos,m.gacc_MetId,m.gacc_MetNombre,m.gacc_MetEstado,f.gacc_FasId,f.gacc_FasNombre, f.gacc_FasEstado,p.gacc_PerId,p.gacc_CodCarId,p.gacc_PerEstado
from GACC_TblFaseDeDesarrollo as F inner join GACC_TblMetodologia as M  on M.gacc_MetId=F.gacc_CodMetId
join GACC_TblPersona as P on P.gacc_PerId= F.gacc_CodPerId 
join GACC_TblPersona AS VMPN ON VMPN.gacc_PerId=M.gacc_CodPerId 
join GACC_TblNombreProyecto AS VMPNP ON VMPNP.gacc_NompId=M.gacc_CodNompId
join GACC_ViewNombreProyectoEmpresa AS VNPE ON VNPE.gacc_NompId=m.gacc_CodNompId
join GACC_TblPersona as per on per.gacc_PerId= vnpe.gacc_CodPerId
join GACC_TblCargo as c on c.gacc_CarId=p.gacc_CodCarId
go
select * from GACC_ViewMetodologiaFase2

--------------------------------------------------------------
create view GACC_ViewFaseActividad
as
select a.gacc_ActId,VNPE.gacc_EmpNombre,vnpe.gacc_NompNombre,vnpe.Nombres_Completos,M.gacc_MetNombre,PERS.gacc_PerPrimerNombre+' '+ PERS.gacc_PerSegundoNombre +' '+ PERS.gacc_PerPrimerApellido+' '+PERS.gacc_PerSegundoApellido as Encargado_Metodologia,F.gacc_FasNombre, PER.gacc_PerPrimerNombre+' '+  PER.gacc_PerSegundoNombre +' '+ PER.gacc_PerPrimerApellido+' '+PER.gacc_PerSegundoApellido as Encargado_Fase, a.gacc_ActNombre,p.gacc_PerPrimerNombre+' '+  p.gacc_PerSegundoNombre +' '+ p.gacc_PerPrimerApellido+' '+p.gacc_PerSegundoApellido as Encargado_Actividad,p.gacc_PerEstado, a.gacc_ActEstado
from GACC_TblFaseDeDesarrollo as F inner join GACC_TblActividad as A on A.gacc_CodFasId=F.gacc_FasId
join GACC_TblPersona as P on P.gacc_PerId= A.gacc_CodPerId
join GACC_TblMetodologia as M on M.gacc_MetId=F.gacc_CodMetId
join GACC_TblPersona as PER on PER.gacc_PerId= F.gacc_CodPerId
join GACC_TblPersona as PERS on PERS.gacc_PerId=M.gacc_CodPerId
join GACC_ViewNombreProyectoEmpresa AS VNPE ON VNPE.gacc_NompId=m.gacc_CodNompId
join GACC_TblPersona as perso on perso.gacc_PerId= vnpe.gacc_CodPerId
go

select * from GACC_ViewFaseActividad
--------------------------------------------------------------
create view GACC_ViewFaseActividad2
as
select VNPE.gacc_EmpId,VNPE.gacc_EmpNombre,VNPE.gacc_EmpEstado,vnpe.gacc_NompId,vnpe.gacc_NompEstado,VNPE.gacc_NompNombre,vnpe.gacc_PerId,vnpe.Nombres_Completos,m.gacc_MetId,m.gacc_MetNombre,m.gacc_MetEstado,f.gacc_FasId,f.gacc_FasNombre, f.gacc_FasEstado, a.gacc_ActId,a.gacc_ActNombre,a.gacc_ActEstado,p.gacc_CodCarId,p.gacc_PerEstado,p.gacc_PerId as idpersona
from GACC_TblFaseDeDesarrollo as F inner join GACC_TblActividad as A on A.gacc_CodFasId=F.gacc_FasId
join GACC_TblPersona as P on P.gacc_PerId= A.gacc_CodPerId
join GACC_TblMetodologia as M on M.gacc_MetId=F.gacc_CodMetId
join GACC_TblPersona as PER on PER.gacc_PerId= F.gacc_CodPerId
join GACC_TblPersona as PERS on PERS.gacc_PerId=M.gacc_CodPerId
join GACC_ViewNombreProyectoEmpresa AS VNPE ON VNPE.gacc_NompId=m.gacc_CodNompId
join GACC_TblPersona as perso on perso.gacc_PerId= vnpe.gacc_CodPerId
join GACC_TblCargo as c on c.gacc_CarId=p.gacc_CodCarId
go

select * from GACC_ViewFaseActividad2
------------------------------------------------------------------
create view GACC_ViewActividadTarea
as
select t.gacc_TarId,VNPE.gacc_EmpNombre,vnpe.gacc_NompNombre,vnpe.Nombres_Completos,M.gacc_MetNombre,PERS.gacc_PerPrimerNombre+' '+ PERS.gacc_PerSegundoNombre +' '+ PERS.gacc_PerPrimerApellido+' '+PERS.gacc_PerSegundoApellido as Encargado_Metodologia,F.gacc_FasNombre, PER.gacc_PerPrimerNombre+' '+  PER.gacc_PerSegundoNombre +' '+ PER.gacc_PerPrimerApellido+' '+PER.gacc_PerSegundoApellido as Encargado_Fase,A.gacc_ActNombre, PERSO.gacc_PerPrimerNombre+' '+  PERSO.gacc_PerSegundoNombre +' '+ PERSO.gacc_PerPrimerApellido+' '+PERSO.gacc_PerSegundoApellido as Encargado_Actividad,T.gacc_TarNombre,t.gacc_TarLineaCodigo,p.gacc_PerPrimerNombre+' '+  p.gacc_PerSegundoNombre +' '+ p.gacc_PerPrimerApellido+' '+p.gacc_PerSegundoApellido as Encargado_Tarea,p.gacc_PerEstado,t.gacc_TarFechaInicio,t.gacc_TarFechaFin,t.gacc_TarEstado
from GACC_TblActividad as A inner join GACC_TblTarea as T on A.gacc_ActId=T.gacc_CodActId
join GACC_TblPersona as P on P.gacc_PerId= T.gacc_CodPerId
join GACC_TblPersona as PERSO on PERSO.gacc_PerId=A.gacc_CodPerId
join GACC_TblFaseDeDesarrollo as F on f.gacc_FasId=A.gacc_CodFasId
join GACC_TblPersona as PER on PER.gacc_PerId= F.gacc_CodPerId
join GACC_TblMetodologia as M on M.gacc_MetId=F.gacc_CodMetId
join GACC_TblPersona as PERS on PERS.gacc_PerId=M.gacc_CodPerId
join GACC_ViewNombreProyectoEmpresa AS VNPE ON VNPE.gacc_NompId=m.gacc_CodNompId
join GACC_TblPersona as person on person.gacc_PerId= vnpe.gacc_CodPerId
go
select * from GACC_ViewActividadTarea

------------------------------------------------------------------
create view GACC_ViewActividadTarea2 
as
select VNPE.gacc_EmpId,VNPE.gacc_EmpNombre,VNPE.gacc_EmpEstado,vnpe.gacc_NompId,vnpe.gacc_NompNombre,vnpe.gacc_NompEstado,vnpe.Nombres_Completos,M.gacc_MetId,M.gacc_MetNombre,M.gacc_MetEstado,PERS.gacc_PerPrimerNombre+' '+ PERS.gacc_PerSegundoNombre +' '+ PERS.gacc_PerPrimerApellido+' '+PERS.gacc_PerSegundoApellido as Encargado_Metodologia,F.gacc_FasId,F.gacc_FasEstado,F.gacc_FasNombre, PER.gacc_PerPrimerNombre+' '+  PER.gacc_PerSegundoNombre +' '+ PER.gacc_PerPrimerApellido+' '+PER.gacc_PerSegundoApellido as Encargado_Fase,A.gacc_ActId,A.gacc_ActNombre,A.gacc_ActEstado, PERSO.gacc_PerPrimerNombre+' '+  PERSO.gacc_PerSegundoNombre +' '+ PERSO.gacc_PerPrimerApellido+' '+PERSO.gacc_PerSegundoApellido as Encargado_Actividad,t.gacc_TarId,T.gacc_TarNombre,t.gacc_TarLineaCodigo,p.gacc_PerPrimerNombre+' '+  p.gacc_PerSegundoNombre +' '+ p.gacc_PerPrimerApellido+' '+p.gacc_PerSegundoApellido as Encargado_Tarea,t.gacc_TarFechaInicio,t.gacc_TarFechaFin,t.gacc_TarEstado,p.gacc_CodCarId,p.gacc_PerEspecialidad,p.gacc_PerId,p.gacc_PerEstado
from GACC_TblActividad as A inner join GACC_TblTarea as T on A.gacc_ActId=T.gacc_CodActId
join GACC_TblPersona as P on P.gacc_PerId= T.gacc_CodPerId
join GACC_TblPersona as PERSO on PERSO.gacc_PerId=A.gacc_CodPerId
join GACC_TblFaseDeDesarrollo as F on f.gacc_FasId=A.gacc_CodFasId
join GACC_TblPersona as PER on PER.gacc_PerId= F.gacc_CodPerId
join GACC_TblMetodologia as M on M.gacc_MetId=F.gacc_CodMetId
join GACC_TblPersona as PERS on PERS.gacc_PerId=M.gacc_CodPerId
join GACC_ViewNombreProyectoEmpresa AS VNPE ON VNPE.gacc_NompId=m.gacc_CodNompId
join GACC_TblPersona as person on person.gacc_PerId= vnpe.gacc_CodPerId
join GACC_TblCargo as c on c.gacc_CarId=p.gacc_CodCarId
go

select * from GACC_ViewActividadTarea2
----------------------------------------------------------
----------------liderproyecto
create view GACC_ViewNombreProyectoEmpresaUsuario
as
select np.gacc_NompId, np.gacc_NompNombre,np.gacc_NompEstado,e.gacc_EmpNombre,e.gacc_EmpId,p.gacc_PerUsuarioNombre
from GACC_TblNombreProyecto as np inner join GACC_TblPersona p on p.gacc_PerId=np.gacc_CodPerId
inner join GACC_TblEmpresa as e on e.gacc_EmpId =np.gacc_CodEmpId
go

select * from GACC_ViewNombreProyectoEmpresaUsuario
------------------------------------------------------------
------------lider proyecto
create view GACC_ViewMetodologiaPersonaUsuario
as
select m.gacc_MetId, E.gacc_EmpNombre,pr.gacc_NompNombre,e.Nombres_Completos,m.gacc_MetNombre,p.gacc_PerPrimerNombre+' '+  P.gacc_PerSegundoNombre +' '+ P.gacc_PerPrimerApellido+' '+P.gacc_PerSegundoApellido as Encargado,p.gacc_PerUsuarioNombre,m.gacc_MetEstado
from GACC_TblMetodologia as M inner join GACC_TblNombreProyecto as PR on PR.gacc_NompId=M.gacc_CodNompId
join GACC_ViewNombreProyectoEmpresa as E on E.gacc_NompId=m.gacc_CodNompId
join GACC_TblPersona as P on P.gacc_PerId=M.gacc_CodPerId
join GACC_TblPersona as per on per.gacc_PerId= e.gacc_CodPerId
go

select * from GACC_ViewMetodologiaPersonaUsuario


--------------------------------------------------------------
--------liderProyecto
create view GACC_ViewMetodologiaPersonaNombreProy3
as
select m.gacc_MetId, E.gacc_EmpNombre,pr.gacc_NompNombre,e.Nombres_Completos,m.gacc_MetNombre,p.gacc_PerPrimerNombre+' '+  P.gacc_PerSegundoNombre +' '+ P.gacc_PerPrimerApellido+' '+P.gacc_PerSegundoApellido as Encargado,m.gacc_MetEstado, p.gacc_PerUsuarioNombre
from GACC_TblMetodologia as M inner join GACC_TblNombreProyecto as PR on PR.gacc_NompId=M.gacc_CodNompId
join GACC_TblPersona as P on P.gacc_PerId=M.gacc_CodPerId
join GACC_ViewNombreProyectoEmpresa as E on E.gacc_NompId=m.gacc_CodNompId
join GACC_TblPersona as per on per.gacc_PerId= e.gacc_CodPerId
go 

select * from GACC_ViewMetodologiaPersonaNombreProy3

--------------------------------------------------------------
--------------lider metodologia
create view GACC_ViewMetodologiaFaseUsuario
as
select f.gacc_FasId, VNPE.gacc_EmpNombre,VMPNP.gacc_NompNombre,vnpe.Nombres_Completos,m.gacc_MetNombre,VMPN.gacc_PerPrimerNombre+' '+  VMPN.gacc_PerSegundoNombre +' '+ VMPN.gacc_PerPrimerApellido+' '+VMPN.gacc_PerSegundoApellido as Encargado_Metodologia,vmpn.gacc_PerUsuarioNombre,f.gacc_FasNombre,p.gacc_PerPrimerNombre+' '+  p.gacc_PerSegundoNombre +' '+ p.gacc_PerPrimerApellido+' '+p.gacc_PerSegundoApellido as Encargado_Fase, f.gacc_FasEstado
from GACC_TblFaseDeDesarrollo as F inner join GACC_TblMetodologia as M  on M.gacc_MetId=F.gacc_CodMetId
join GACC_TblPersona as P on P.gacc_PerId= F.gacc_CodPerId 
join GACC_TblPersona AS VMPN ON VMPN.gacc_PerId=M.gacc_CodPerId 
join GACC_TblNombreProyecto AS VMPNP ON VMPNP.gacc_NompId=M.gacc_CodNompId
join GACC_ViewNombreProyectoEmpresa AS VNPE ON VNPE.gacc_NompId=m.gacc_CodNompId
join GACC_TblPersona as per on per.gacc_PerId= vnpe.gacc_CodPerId
go


select * from GACC_ViewMetodologiaFaseUsuario

--------------------------------------------------------------
------metodologia------------
create view GACC_ViewFaseActividadUsuarioUsuario
as
select a.gacc_ActId,VNPE.gacc_EmpNombre,vnpe.gacc_NompNombre,vnpe.Nombres_Completos,M.gacc_MetNombre,PERS.gacc_PerPrimerNombre+' '+ PERS.gacc_PerSegundoNombre +' '+ PERS.gacc_PerPrimerApellido+' '+PERS.gacc_PerSegundoApellido as Encargado_Metodologia,pers.gacc_PerUsuarioNombre,F.gacc_FasNombre, PER.gacc_PerPrimerNombre+' '+  PER.gacc_PerSegundoNombre +' '+ PER.gacc_PerPrimerApellido+' '+PER.gacc_PerSegundoApellido as Encargado_Fase, a.gacc_ActNombre,p.gacc_PerPrimerNombre+' '+  p.gacc_PerSegundoNombre +' '+ p.gacc_PerPrimerApellido+' '+p.gacc_PerSegundoApellido as Encargado_Actividad, a.gacc_ActEstado
from GACC_TblFaseDeDesarrollo as F inner join GACC_TblActividad as A on A.gacc_CodFasId=F.gacc_FasId
join GACC_TblPersona as P on P.gacc_PerId= A.gacc_CodPerId
join GACC_TblMetodologia as M on M.gacc_MetId=F.gacc_CodMetId
join GACC_TblPersona as PER on PER.gacc_PerId= F.gacc_CodPerId
join GACC_TblPersona as PERS on PERS.gacc_PerId=M.gacc_CodPerId
join GACC_ViewNombreProyectoEmpresa AS VNPE ON VNPE.gacc_NompId=m.gacc_CodNompId
join GACC_TblPersona as perso on perso.gacc_PerId= vnpe.gacc_CodPerId
go

select * from GACC_ViewFaseActividadUsuarioUsuario

----------------------------------------------------------------
---------lider metodologia
create view GACC_ViewActividadTareaUsuario
as
select t.gacc_TarId,VNPE.gacc_EmpNombre,vnpe.gacc_NompNombre,vnpe.Nombres_Completos,M.gacc_MetNombre,PERS.gacc_PerPrimerNombre+' '+ PERS.gacc_PerSegundoNombre +' '+ PERS.gacc_PerPrimerApellido+' '+PERS.gacc_PerSegundoApellido as Encargado_Metodologia,pers.gacc_PerUsuarioNombre,F.gacc_FasNombre, PER.gacc_PerPrimerNombre+' '+  PER.gacc_PerSegundoNombre +' '+ PER.gacc_PerPrimerApellido+' '+PER.gacc_PerSegundoApellido as Encargado_Fase,A.gacc_ActNombre, PERSO.gacc_PerPrimerNombre+' '+  PERSO.gacc_PerSegundoNombre +' '+ PERSO.gacc_PerPrimerApellido+' '+PERSO.gacc_PerSegundoApellido as Encargado_Actividad,T.gacc_TarNombre,t.gacc_TarLineaCodigo,p.gacc_PerPrimerNombre+' '+  p.gacc_PerSegundoNombre +' '+ p.gacc_PerPrimerApellido+' '+p.gacc_PerSegundoApellido as Encargado_Tarea,t.gacc_TarFechaInicio,t.gacc_TarFechaFin,t.gacc_TarEstado
from GACC_TblActividad as A inner join GACC_TblTarea as T on A.gacc_ActId=T.gacc_CodActId
join GACC_TblPersona as P on P.gacc_PerId= T.gacc_CodPerId
join GACC_TblPersona as PERSO on PERSO.gacc_PerId=A.gacc_CodPerId
join GACC_TblFaseDeDesarrollo as F on f.gacc_FasId=A.gacc_CodFasId
join GACC_TblPersona as PER on PER.gacc_PerId= F.gacc_CodPerId
join GACC_TblMetodologia as M on M.gacc_MetId=F.gacc_CodMetId
join GACC_TblPersona as PERS on PERS.gacc_PerId=M.gacc_CodPerId
join GACC_ViewNombreProyectoEmpresa AS VNPE ON VNPE.gacc_NompId=m.gacc_CodNompId
join GACC_TblPersona as person on person.gacc_PerId= vnpe.gacc_CodPerId
go

select * from GACC_ViewActividadTareaUsuario

----------------------------------------------------------------
------vista liderfase de desarrollo
create view GACC_ViewFaseActividadTarea
as
select t.gacc_TarId,VNPE.gacc_EmpNombre,vnpe.gacc_NompNombre,vnpe.Nombres_Completos,M.gacc_MetNombre,PERS.gacc_PerPrimerNombre+' '+ PERS.gacc_PerSegundoNombre +' '+ PERS.gacc_PerPrimerApellido+' '+PERS.gacc_PerSegundoApellido as Encargado_Metodologia,F.gacc_FasNombre, PER.gacc_PerPrimerNombre+' '+  PER.gacc_PerSegundoNombre +' '+ PER.gacc_PerPrimerApellido+' '+PER.gacc_PerSegundoApellido as Encargado_Fase,per.gacc_PerUsuarioNombre,A.gacc_ActNombre, PERSO.gacc_PerPrimerNombre+' '+  PERSO.gacc_PerSegundoNombre +' '+ PERSO.gacc_PerPrimerApellido+' '+PERSO.gacc_PerSegundoApellido as Encargado_Actividad,T.gacc_TarNombre,t.gacc_TarLineaCodigo,p.gacc_PerPrimerNombre+' '+  p.gacc_PerSegundoNombre +' '+ p.gacc_PerPrimerApellido+' '+p.gacc_PerSegundoApellido as Encargado_Tarea,t.gacc_TarFechaInicio,t.gacc_TarFechaFin,t.gacc_TarEstado
from GACC_TblActividad as A inner join GACC_TblTarea as T on A.gacc_ActId=T.gacc_CodActId
join GACC_TblPersona as P on P.gacc_PerId= T.gacc_CodPerId
join GACC_TblPersona as PERSO on PERSO.gacc_PerId=A.gacc_CodPerId
join GACC_TblFaseDeDesarrollo as F on f.gacc_FasId=A.gacc_CodFasId
join GACC_TblPersona as PER on PER.gacc_PerId= F.gacc_CodPerId
join GACC_TblMetodologia as M on M.gacc_MetId=F.gacc_CodMetId
join GACC_TblPersona as PERS on PERS.gacc_PerId=M.gacc_CodPerId
join GACC_ViewNombreProyectoEmpresa AS VNPE ON VNPE.gacc_NompId=m.gacc_CodNompId
join GACC_TblPersona as person on person.gacc_PerId= vnpe.gacc_CodPerId
go

select * from GACC_ViewFaseActividadTarea

--------------------------------------------------------------
--------------lider fase de desarrollo
create view GACC_ViewMetodologiaFaseUsuario2
as
select f.gacc_FasId, VNPE.gacc_EmpNombre,VMPNP.gacc_NompNombre,vnpe.Nombres_Completos,m.gacc_MetNombre,VMPN.gacc_PerPrimerNombre+' '+  VMPN.gacc_PerSegundoNombre +' '+ VMPN.gacc_PerPrimerApellido+' '+VMPN.gacc_PerSegundoApellido as Encargado_Metodologia,f.gacc_FasNombre,p.gacc_PerPrimerNombre+' '+  p.gacc_PerSegundoNombre +' '+ p.gacc_PerPrimerApellido+' '+p.gacc_PerSegundoApellido as Encargado_Fase,p.gacc_PerUsuarioNombre, f.gacc_FasEstado
from GACC_TblFaseDeDesarrollo as F inner join GACC_TblMetodologia as M  on M.gacc_MetId=F.gacc_CodMetId
join GACC_TblPersona as P on P.gacc_PerId= F.gacc_CodPerId 
join GACC_TblPersona AS VMPN ON VMPN.gacc_PerId=M.gacc_CodPerId 
join GACC_TblNombreProyecto AS VMPNP ON VMPNP.gacc_NompId=M.gacc_CodNompId
join GACC_ViewNombreProyectoEmpresa AS VNPE ON VNPE.gacc_NompId=m.gacc_CodNompId
join GACC_TblPersona as per on per.gacc_PerId= vnpe.gacc_CodPerId
go


select * from GACC_ViewMetodologiaFaseUsuario2

--------------------------------------------------------------
--------fase de desarrollo-------
create view GACC_ViewFaseActividadUsuarioUsuario2
as
select a.gacc_ActId,VNPE.gacc_EmpNombre,vnpe.gacc_NompNombre,vnpe.Nombres_Completos,M.gacc_MetNombre,PERS.gacc_PerPrimerNombre+' '+ PERS.gacc_PerSegundoNombre +' '+ PERS.gacc_PerPrimerApellido+' '+PERS.gacc_PerSegundoApellido as Encargado_Metodologia,F.gacc_FasNombre, PER.gacc_PerPrimerNombre+' '+  PER.gacc_PerSegundoNombre +' '+ PER.gacc_PerPrimerApellido+' '+PER.gacc_PerSegundoApellido as Encargado_Fase,per.gacc_PerUsuarioNombre, a.gacc_ActNombre,p.gacc_PerPrimerNombre+' '+  p.gacc_PerSegundoNombre +' '+ p.gacc_PerPrimerApellido+' '+p.gacc_PerSegundoApellido as Encargado_Actividad, a.gacc_ActEstado
from GACC_TblFaseDeDesarrollo as F inner join GACC_TblActividad as A on A.gacc_CodFasId=F.gacc_FasId
join GACC_TblPersona as P on P.gacc_PerId= A.gacc_CodPerId
join GACC_TblMetodologia as M on M.gacc_MetId=F.gacc_CodMetId
join GACC_TblPersona as PER on PER.gacc_PerId= F.gacc_CodPerId
join GACC_TblPersona as PERS on PERS.gacc_PerId=M.gacc_CodPerId
join GACC_ViewNombreProyectoEmpresa AS VNPE ON VNPE.gacc_NompId=m.gacc_CodNompId
join GACC_TblPersona as perso on perso.gacc_PerId= vnpe.gacc_CodPerId
go

select * from GACC_ViewFaseActividadUsuarioUsuario2

------------------------------------------------------------
--------LIDER ACTIVIDAD
create view GACC_ViewFaseActividad3
as
select a.gacc_ActId,VNPE.gacc_EmpNombre,vnpe.gacc_NompNombre,vnpe.Nombres_Completos,M.gacc_MetNombre,PERS.gacc_PerPrimerNombre+' '+ PERS.gacc_PerSegundoNombre +' '+ PERS.gacc_PerPrimerApellido+' '+PERS.gacc_PerSegundoApellido as Encargado_Metodologia,F.gacc_FasNombre, PER.gacc_PerPrimerNombre+' '+  PER.gacc_PerSegundoNombre +' '+ PER.gacc_PerPrimerApellido+' '+PER.gacc_PerSegundoApellido as Encargado_Fase, a.gacc_ActNombre,p.gacc_PerPrimerNombre+' '+  p.gacc_PerSegundoNombre +' '+ p.gacc_PerPrimerApellido+' '+p.gacc_PerSegundoApellido as Encargado_Actividad,p.gacc_PerUsuarioNombre, a.gacc_ActEstado
from GACC_TblFaseDeDesarrollo as F inner join GACC_TblActividad as A on A.gacc_CodFasId=F.gacc_FasId
join GACC_TblPersona as P on P.gacc_PerId= A.gacc_CodPerId
join GACC_TblMetodologia as M on M.gacc_MetId=F.gacc_CodMetId
join GACC_TblPersona as PER on PER.gacc_PerId= F.gacc_CodPerId
join GACC_TblPersona as PERS on PERS.gacc_PerId=M.gacc_CodPerId
join GACC_ViewNombreProyectoEmpresa AS VNPE ON VNPE.gacc_NompId=m.gacc_CodNompId
join GACC_TblPersona as perso on perso.gacc_PerId= vnpe.gacc_CodPerId
go

select * from GACC_ViewFaseActividad3
------------------------------------------------------------------------------
---------------lider de actividad
create view GACC_ViewActividadTareaUsuario4
as
select t.gacc_TarId,VNPE.gacc_EmpNombre,vnpe.gacc_NompNombre,vnpe.Nombres_Completos,M.gacc_MetNombre,PERS.gacc_PerPrimerNombre+' '+ PERS.gacc_PerSegundoNombre +' '+ PERS.gacc_PerPrimerApellido+' '+PERS.gacc_PerSegundoApellido as Encargado_Metodologia,F.gacc_FasNombre, PER.gacc_PerPrimerNombre+' '+  PER.gacc_PerSegundoNombre +' '+ PER.gacc_PerPrimerApellido+' '+PER.gacc_PerSegundoApellido as Encargado_Fase,A.gacc_ActNombre, PERSO.gacc_PerPrimerNombre+' '+  PERSO.gacc_PerSegundoNombre +' '+ PERSO.gacc_PerPrimerApellido+' '+PERSO.gacc_PerSegundoApellido as Encargado_Actividad,perso.gacc_PerUsuarioNombre,T.gacc_TarNombre,t.gacc_TarLineaCodigo,p.gacc_PerPrimerNombre+' '+  p.gacc_PerSegundoNombre +' '+ p.gacc_PerPrimerApellido+' '+p.gacc_PerSegundoApellido as Encargado_Tarea,t.gacc_TarFechaInicio,t.gacc_TarFechaFin,t.gacc_TarEstado
from GACC_TblActividad as A inner join GACC_TblTarea as T on A.gacc_ActId=T.gacc_CodActId
join GACC_TblPersona as P on P.gacc_PerId= T.gacc_CodPerId
join GACC_TblPersona as PERSO on PERSO.gacc_PerId=A.gacc_CodPerId
join GACC_TblFaseDeDesarrollo as F on f.gacc_FasId=A.gacc_CodFasId
join GACC_TblPersona as PER on PER.gacc_PerId= F.gacc_CodPerId
join GACC_TblMetodologia as M on M.gacc_MetId=F.gacc_CodMetId
join GACC_TblPersona as PERS on PERS.gacc_PerId=M.gacc_CodPerId
join GACC_ViewNombreProyectoEmpresa AS VNPE ON VNPE.gacc_NompId=m.gacc_CodNompId
join GACC_TblPersona as person on person.gacc_PerId= vnpe.gacc_CodPerId
go

select * from GACC_ViewActividadTareaUsuario4

----------------------------------------------------------------
---------------------vistaLiderdedesarrollo
create view GACC_ViewActividadTareaUsuario3
as
select t.gacc_TarId,VNPE.gacc_EmpNombre,vnpe.gacc_NompNombre,vnpe.Nombres_Completos,M.gacc_MetNombre,PERS.gacc_PerPrimerNombre+' '+ PERS.gacc_PerSegundoNombre +' '+ PERS.gacc_PerPrimerApellido+' '+PERS.gacc_PerSegundoApellido as Encargado_Metodologia,F.gacc_FasNombre, PER.gacc_PerPrimerNombre+' '+  PER.gacc_PerSegundoNombre +' '+ PER.gacc_PerPrimerApellido+' '+PER.gacc_PerSegundoApellido as Encargado_Fase,A.gacc_ActNombre, PERSO.gacc_PerPrimerNombre+' '+  PERSO.gacc_PerSegundoNombre +' '+ PERSO.gacc_PerPrimerApellido+' '+PERSO.gacc_PerSegundoApellido as Encargado_Actividad,T.gacc_TarNombre,t.gacc_TarLineaCodigo,p.gacc_PerPrimerNombre+' '+  p.gacc_PerSegundoNombre +' '+ p.gacc_PerPrimerApellido+' '+p.gacc_PerSegundoApellido as Encargado_Tarea,p.gacc_PerUsuarioNombre,t.gacc_TarFechaInicio,t.gacc_TarFechaFin,t.gacc_TarEstado
from GACC_TblActividad as A inner join GACC_TblTarea as T on A.gacc_ActId=T.gacc_CodActId
join GACC_TblPersona as P on P.gacc_PerId= T.gacc_CodPerId
join GACC_TblPersona as PERSO on PERSO.gacc_PerId=A.gacc_CodPerId
join GACC_TblFaseDeDesarrollo as F on f.gacc_FasId=A.gacc_CodFasId
join GACC_TblPersona as PER on PER.gacc_PerId= F.gacc_CodPerId
join GACC_TblMetodologia as M on M.gacc_MetId=F.gacc_CodMetId
join GACC_TblPersona as PERS on PERS.gacc_PerId=M.gacc_CodPerId
join GACC_ViewNombreProyectoEmpresa AS VNPE ON VNPE.gacc_NompId=m.gacc_CodNompId
join GACC_TblPersona as person on person.gacc_PerId= vnpe.gacc_CodPerId
go

select * from GACC_ViewActividadTareaUsuario3

-------------------------------------------------------------------------------------
create view GACC_ViewEmpresaNombreUsuario
as
select p.gacc_EmpId,p.gacc_EmpNombre,per.gacc_PerUsuarioNombre
from GACC_TblEmpresa as p inner join GACC_TblPersona as per on per.gacc_CodEmpId=p.gacc_EmpId
go

select * from GACC_ViewEmpresaNombreUsuario

-------------------------------------------------------------------------------------
create view GACC_ViewTablaProyecto
as
select p.gacc_ProId,e.gacc_EmpNombre,np.gacc_NompNombre,p.gacc_ProLineasCodigo,p.gacc_ProLineaCodigoExistente,p.gacc_ProLenguaje,p.gacc_ProGestorBaseDatos,p.gacc_ProTipoProyecto,p.gacc_ProModeloProyecto,p.gacc_ProEsfuerzoNominal,p.gacc_ProEsfuerzoAjustado,p.gacc_ProTiempo,p.gacc_ProFechaInicio,p.gacc_ProFechaFin,p.gacc_ProCostoTrabajadores,p.gacc_ProCostoCostoIndirectos,p.gacc_ProCostoTotal,p.gacc_ProNumeroPersonas,p.gacc_ProEstado
from GACC_TblProyecto as p inner join GACC_TblEmpresa as e on p.gacc_CodEmpId=e.gacc_EmpId
inner join GACC_TblNombreProyecto as np on p.gacc_CodNompId=np.gacc_NompId
go

select * from GACC_ViewTablaProyecto

------------------------------------------------------------------------------------
create view GACC_ViewTablaProyecto2
as
select p.gacc_ProId,e.gacc_EmpId,e.gacc_EmpNombre,np.gacc_NompId,np.gacc_NompNombre,p.gacc_ProLineasCodigo,p.gacc_ProLineaCodigoExistente,p.gacc_ProLenguaje,p.gacc_ProGestorBaseDatos,p.gacc_ProTipoProyecto,p.gacc_ProModeloProyecto,p.gacc_ProEsfuerzoNominal,p.gacc_ProEsfuerzoAjustado,p.gacc_ProTiempo,p.gacc_ProFechaInicio,p.gacc_ProFechaFin,p.gacc_ProCostoTrabajadores,p.gacc_ProCostoCostoIndirectos,p.gacc_ProCostoTotal,p.gacc_ProNumeroPersonas,p.gacc_ProEstado
from GACC_TblProyecto as p inner join GACC_TblEmpresa as e on p.gacc_CodEmpId=e.gacc_EmpId
inner join GACC_TblNombreProyecto as np on p.gacc_CodNompId=np.gacc_NompId
go

select * from GACC_ViewTablaProyecto2
------------------------------------------------------------------------------------
create view GACC_ViewTablaProyecto3
as
select p.gacc_ProId,e.gacc_EmpId,e.gacc_EmpNombre,np.gacc_NompId,np.gacc_NompNombre,np.gacc_CodPerId,per.gacc_PerUsuarioNombre,p.gacc_ProLineasCodigo,p.gacc_ProLineaCodigoExistente,p.gacc_ProLenguaje,p.gacc_ProGestorBaseDatos,p.gacc_ProTipoProyecto,p.gacc_ProModeloProyecto,p.gacc_ProEsfuerzoNominal,p.gacc_ProEsfuerzoAjustado,p.gacc_ProTiempo,p.gacc_ProFechaInicio,p.gacc_ProFechaFin,p.gacc_ProCostoTrabajadores,p.gacc_ProCostoCostoIndirectos,p.gacc_ProCostoTotal,p.gacc_ProNumeroPersonas,p.gacc_ProEstado
from GACC_TblProyecto as p inner join GACC_TblEmpresa as e on p.gacc_CodEmpId=e.gacc_EmpId
inner join GACC_TblNombreProyecto as np on p.gacc_CodNompId=np.gacc_NompId
inner join GACC_TblPersona as per on np.gacc_CodPerId=per.gacc_PerId
go

select * from GACC_ViewTablaProyecto3

------------------------------------------------------------------------------------
create view GACC_ViewPersonaProyecto
as
select pp.gacc_ProPerId,p.gacc_PerId,p.gacc_PerPrimerNombre+' '+p.gacc_PerSegundoNombre+' '+p.gacc_PerPrimerApellido+' '+p.gacc_PerSegundoApellido as Nombre,c.gacc_CarNombre,p.gacc_PerSalario,e.gacc_EmpNombre as Empresa_Trabajando,p.gacc_PerEstado,np.gacc_NompId,np.gacc_NompNombre,em.gacc_EmpNombre,em.gacc_EmpId,np.gacc_NompEstado
from GACC_TblProyectoTblPersona as pp inner join GACC_TblPersona as p on pp.gacc_CodPerId=p.gacc_PerId
inner join GACC_TblNombreProyecto as np on pp.gacc_CodNompId=np.gacc_NompId
inner join GACC_TblCargo as c on p.gacc_CodCarId=c.gacc_CarId
inner join GACC_TblEmpresa as e on p.gacc_CodEmpId=e.gacc_EmpId
inner join GACC_TblEmpresa as em on np.gacc_CodEmpId=em.gacc_EmpId
go
select * from GACC_ViewPersonaProyecto
--------------------------------------------------------------------------------------
create view GACC_ViewProyectoCosto
as
select cp.gacc_ProCostId,c.gacc_CostId,c.gacc_CostNombre,c.gacc_CostValor,c.gacc_CostEstado,np.gacc_NompId,np.gacc_NompNombre,np.gacc_NompEstado,e.gacc_EmpNombre,e.gacc_EmpId
from GACC_TblProyectoTblCostoIndirecto as cp inner join GACC_TblCostoIndirecto as c on cp.gacc_CodCostId=c.gacc_CostId
inner join GACC_TblNombreProyecto as np on np.gacc_NompId=cp.gacc_CodNompId
inner join GACC_TblEmpresa as e on np.gacc_CodEmpId=e.gacc_EmpId
go
select * from GACC_ViewProyectoCosto

-----------------------------------------------------------------------------------------------
create view GACC_ViewCosto
as
select c.*,np.*,e.*
from GACC_TblCostoIndirecto as c inner join GACC_TblNombreProyecto as np on np.gacc_NompId=c.gacc_CostNombreProyectoID 
inner join GACC_TblEmpresa as e on e.gacc_EmpId=np.gacc_CodEmpId
go
select * from GACC_ViewCosto
select * from GACC_ViewPersonaProyecto
select * from GACC_ViewTablaProyecto2
