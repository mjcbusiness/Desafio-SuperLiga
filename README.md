# Desafio-SuperLiga - Aplicación de Consola .Net

Este Proyecto es una **aplicación de consola desarrollada en C# (.NET)** que procesa un archivo `socios.csv` 
y muestra distintos **análisis y listados estadísticos** sobre los socios de clubes de futbol

El Objetivo del desafio es demostrar:
- Lectura y procesamiento de archivos CSV
- Uso de LINQ para consultas y agregaciones
- Buenas prácticas de organización de código
- Diseño claro y entendible de una app de consola
- Separación de responsabilidades (UI,Lógica, Dominio,Infraestructura)

---
## ¿Qué hace el programa?

A partir del archivo `socios.csv`, la aplicación permite desde un **Menú interactivo**

1. **Mostrar Cantidad total de personas**
2. **Mostrar Promedio edad socios Racing**
3. **Listado 100 personas** que:
   - Están casadas
   - Tienen estudios universitarios
   - Estánn ordenadas de menor a mayor de edad
   - Muestra: Nombre, Edad y Equipo
4. **Listado 5 nombres más comunes** entre los hinchas de River
5. **Estadísticas por equipo**, ordenadas de mayor a menor por cantidad de socios:
   - Cantidad total de socios
   - Promedio de edad
   - Edad mínima
   - Edad máxima
0. Salir

Todo se visualiza de forma clara en la **consola**, con pantallas separadas y navegacion simple.

---

## Estructura del proyecto

```
Desafio-SuperLiga/
│
├── Program.cs → Punto de entrada
│
├── Domain/
│ └── Socio.cs → Modelo de dominio
│
├── Infrastructure/
│ └── AccionesSocio.cs → Lectura y parseo del CSV
│
├── Application/
│ ├── SociosService.cs → Lógica principal del negocio
│
├── UI/
│ ├── Menu.cs → Menú y navegación
│ └── RenderConsola.cs → Renderizado de tablas y pantallas
│
└── Plantilla
  ├──socios.csv → Archivo de entrada
```
## Campos utilizados

- nombre
- edad
- equipo
- estadoCivil
- nivelEducativo

## Cómo ejecutar el proyecto

1. Requisitos
  - .Net SDK 8
  Verifica la instalación con
```
dotnet --version
```
---
2. Clonar el repositorio

```
git clone https://github.com/mjcbusiness/Desafio-SuperLiga.git
```
---
3. Colocar el archivo CSV
   Copiar `socios.csv` en la raiz del proyecto, junto al `.csproj`
---

4. Correr el proyecto

---

# Autor
**Jonatan Maximiliano Cari
Desarrollador FullStack (.NET / Angular)**
