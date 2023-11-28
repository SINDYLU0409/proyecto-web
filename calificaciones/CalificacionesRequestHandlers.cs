public static class CalificacionesRequestHandlers{

  public static IResult MostrarCalificaciones() {
    
        List<CalificacionMateria> list = new List<CalificacionMateria>();
  CalificacionMateria m1 = new CalificacionMateria();
  m1.Calificacion = 10;
  m1.Materia = "Programacion Orientada a objetos";
  m1.Parcial = 1;
  m1.NumControl = 22328051051234;

CalificacionMateria m2 = new CalificacionMateria();
m2.Calificacion = 9;
m2.Materia = "Programacion Orientada a eventos";
m2.Parcial = 1;
m2.NumControl = 22328051051234;

CalificacionMateria m3 = new CalificacionMateria();
m3.Calificacion = 7.2;
m3.Materia = "Algebra";
m3.Parcial = 1;
m3.NumControl = 22328051051234;

CalificacionMateria m4 = new CalificacionMateria();
m4.Calificacion= 8;
m4.Materia ="biologia";
m4.Parcial = 1;
m4.NumControl = 22328051051234;

CalificacionMateria m5 = new CalificacionMateria();
m5.Calificacion = 9;
m5.Materia = "Ingles";
m5.Parcial = 1;
m5.NumControl = 22328051051234;

CalificacionMateria m6 = new CalificacionMateria();
m6.Calificacion = 10;
m6.Materia = "Etica";
m6.Parcial = 1;
m6.NumControl = 22328051051234;

CalificacionMateria c1 = new CalificacionMateria();
c1.Calificacion = 10;
c1.Materia = "Programacion orientada a objetos";
c1.Parcial = 2;
c1.NumControl = 22328051051234;

CalificacionMateria c2 = new CalificacionMateria();
c2.Calificacion = 10;
c2.Materia = "Programacion orientada a eventos";
c2.Parcial = 2;
c2.NumControl = 22328051051234;

CalificacionMateria c3 = new CalificacionMateria();
c3.Calificacion = 9;
c3.Materia = "Algebra";
c3.Parcial = 2;
c3.NumControl = 22328051051234;

CalificacionMateria c4 = new CalificacionMateria();
c4.Calificacion = 8.5;
c4.Materia = "biologia";
c4.Parcial = 2;
c4.NumControl = 22328051051234;

CalificacionMateria c5 = new CalificacionMateria();
c5.Calificacion = 9;
c5.Materia = "Ingles";
c5.Parcial = 2;
c5.NumControl = 22328051051234;

CalificacionMateria c6 = new CalificacionMateria();
c6.Calificacion = 9;
c6.Materia = "Etica";
c6.Parcial = 2;
c6.NumControl = 22328051051234;

CalificacionMateria a1 = new CalificacionMateria();
a1.Calificacion = 10;
a1.Materia = "Programacion orientada a objetos";
a1.Parcial = 3;
a1.NumControl = 22328051051234;

CalificacionMateria a2 = new CalificacionMateria();
a2.Calificacion = 10;
a2.Materia = "Programacion orientada a eventos";
a2.Parcial = 3;
a2.NumControl = 22328051051234;

CalificacionMateria a3 = new CalificacionMateria();
a3.Calificacion = 8;
a3.Materia = "Algebra";
a3.Parcial = 3;
a3.NumControl = 22328051051234;

CalificacionMateria a4 = new CalificacionMateria();
a4.Calificacion = 9;
a4.Materia = "biologia";
a4.Parcial = 3;
a4.NumControl = 22328051051234;

CalificacionMateria a5 = new CalificacionMateria();
a5.Calificacion = 8;
a5.Materia = "Ingles";
a5.Parcial = 3;
a5.NumControl = 22328051051234;

CalificacionMateria a6 = new CalificacionMateria();
a6.Calificacion = 7;
a6.Materia = "Etica";
a6.Parcial = 3;
a6.NumControl = 22328051051234;
  list.Add(m1);
  list.Add(m2);
  list.Add(m3);
  list.Add(m4);
  list.Add(m5);
  list.Add(m6);
  list.Add(c1);
  list.Add(c2);

  list.Add(c3);
  list.Add(c4);
  list.Add(c5);
  list.Add(c6);
  list.Add(a1);
  list.Add(a2);
  list.Add(a3);
  list.Add(a4);
  list.Add(a5);
  list.Add(a6);
  return Results.Ok(list);
    

}
public static IResult MostrarCalificacionesAlumno(long numControl,
  int parcial, bool soloAsignatura, bool soloAcreditadas){

    if(numControl == 22328051051234){ 
        List<CalificacionMateria> list = new List<CalificacionMateria>();
  CalificacionMateria m1 = new CalificacionMateria();
  m1.Calificacion = 10;
  m1.Materia = "Programacion Orientada a objetos";
  m1.Parcial = 1;
  m1.NumControl = 22328051051234;
  list.Add(m1);
  
       CalificacionMateria m2 = new CalificacionMateria();
  m2.Calificacion = 9;
  m2.Materia = "Programacion Orientada a eventos";
  m2.Parcial = 1;
  m2.NumControl = 22328051051234;
  list.Add(m2);
  
       CalificacionMateria m3 = new CalificacionMateria();
  m3.Calificacion = 7.2;
  m3.Materia = "Algebra";
  m3.Parcial = 1;
  m3.NumControl = 22328051051234;
  list.Add(m3);

  CalificacionMateria m4 = new CalificacionMateria();
  m4.Calificacion = 8;
  m4.Materia = "biologia";
  m4.Parcial = 1;
  m4.NumControl = 22328051051234;
  list.Add(m4);

  CalificacionMateria m5 = new CalificacionMateria();
  m5.Calificacion = 9;
  m5.Materia = "Ingles";
  m5.Parcial = 1;
  m5.NumControl = 22328051051234;
  list.Add(m5);

  CalificacionMateria m6 = new CalificacionMateria();
  m6.Calificacion = 10;
  m6.Materia = "Etica";
  m6.Parcial = 1;
  m6.NumControl = 22328051051234;
  list.Add(m6);
  return Results.Ok(list);
    } 
    else{
      return Results.NotFound($"no existe un alumno con numero de control {numControl}");

    }
}

  }



