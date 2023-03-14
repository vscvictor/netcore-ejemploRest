# Information
Implementación de test para realizar pruebas unitarias de la capa Repositorio e infraestructure.

	WSEjercicioRest.Test						
						|
						Infraestructura
							|
							Services
								|
								ServiceName
						|
						Repositorio
							|
							Services
								|
								ServiceName
						|
						Utilitarios
						
													
# Documentation
ServicesName : nombre del servicio Externo. Ejemplo: Pagueya, Sipecom, RegistroCivil, LinkSolutions, etc.

Infraestructura: Pruebas unitarias de la capa infraestructure.

Repositorio: Pruebas unitarias de la capa Repositorio.

Utilitarios: Se definen las clases con datos de entrada y salida que se van a usar en las pruebas unitarias.


# Build 
ServiceNameInfraestructuraTest.cs: Pruebas Unitarias de la capa Infraestructure. 

ServiceNameRepositorioTest.cs: Pruebas Unitarias de la capa Repositorio. 

DataEntrada.cs: Se definen las entradas que se van a usar en las pruebas unitarias.

DataSalida.cs: Se definen las salidas que se van a usar en las pruebas unitarias.


# Nuget Packages
1.  Microsoft.NET.Test.Sdk(17.1.0)
2.  NUnit(3.13.3)
3.  NUnit3TestAdapter(4.2.1)
4.  Moq(4.18.1)
5.  NUnit.Analyzers(3.3.0)
6.  coverlet.collector(3.1.2)
