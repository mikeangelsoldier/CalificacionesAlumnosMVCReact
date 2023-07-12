import { useState, useEffect } from 'react';
import { Col, Container, Row, Card, CardHeader, CardBody, Button } from "reactstrap"
import TablaEstudianteClases from "./TablaEstudianteClases";
import ModalEstudianteClases from './ModalEstudianteClases';
import { useParams } from 'react-router-dom';
import ModalCalificar from './ModalCalificar';

const CalificacionesComponent = () => {
  let { idEstudiante } = useParams();

  const [estudianteCursos, setEstudianteCursos] = useState([]);

  const [showModalAgregarACurso, setShowModalAgregarACurso] = useState(false);
  const [allCursos, setAllCursos] = useState([]);
  const [cursosDisponibles, setCursosDisponibles] = useState([]);

  const [showModalCalificacion, setShowModalCalificacion] = useState(false);
  const [estudianteCursoAEditar, setEstudianteCursoAEditar] = useState(null);







  const mostrarEstudianteCursos = async () => {


    console.log("idEstudiante: ", idEstudiante);


    var response = await fetch("api/estudiantes/lista/" + idEstudiante + "/ListaClasesDeEstudiante");

    console.log(response);
    if (response.ok) {
      var data = await response.json();

      await setEstudianteCursos(data);

      // console.log("estudianteCursos[]: ", estudianteCursos);



    } else {
      console.log("Error en los datos de la lista");
    }
  }

  const loadAllCursos = async () => {
    console.log("loadAllCursos() ");


    var response2 = await fetch("api/cursos/CursosDisponibles/" + idEstudiante);

    if (response2.ok) {
      var data2 = await response2.json();

      await setAllCursos(data2);
      
    

      // INICIO calcularCursosDisponibles
      if (estudianteCursos.length > 0 & data2.length > 0) {
        var arrCursosDisponibles = await data2.filter(ar => !estudianteCursos.find(rm => (ar.id == rm.cursoId)));
         await setCursosDisponibles(arrCursosDisponibles);
        console.log("cursosDisponibles[]: ", cursosDisponibles);
      } else {
         await setCursosDisponibles(data2);
  
        console.log("cursosDisponibles[]: ", cursosDisponibles);
      }
      // FIN calcularCursosDisponibles
      

      
      


    } else {
      console.log("Error en los datos de la lista de AllCursos");
    }
  }



  const abrirModalRegistrarACursos = async () => {

    await loadAllCursos();

    await setShowModalAgregarACurso(!showModalAgregarACurso)
  }




  const registrarACurso = async (idCurso) => {

    let data = new Object();
    data.estudianteId = idEstudiante;
    data.cursoId = idCurso;


    data.calificacion = null;
    data.id = 0;

    data.estudiante = null;
    data.curso = null;

    console.log("registrarACurso Data: ", data);

    const response = await fetch("api/estudiantes/RegistrarEstudianteACurso", {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json;charset=utf-8'
      },
      body: JSON.stringify(data)
      // body: JSON.stringify(estudianteCurso)
    })

    if (response.ok) {
      setShowModalAgregarACurso(!showModalAgregarACurso);
      await mostrarEstudianteCursos();
    }
    
  }

  /*
    const editarEstudiante = async (estudiante) => {
      const response = await fetch("api/estudiantes/Editar", {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(estudiante)
      })
  
      if (response.ok) {
        setShowModalAgregarACurso(!showModalAgregarACurso);
        mostrarEstudianteCursos();
      }
    }
    
    */


  const editarCalificacion = async (estudianteCurso) => {

    let data = new Object();
    data.calificacion = estudianteCurso.calificacion;
    data.estudianteId = estudianteCurso.estudianteId;
    data.cursoId = estudianteCurso.cursoId;
    data.id = estudianteCurso.id;

    data.estudiante = null;

    data.curso = null;

    const response = await fetch("api/estudiantes/EditarEstudianteCurso", {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json;charset=utf-8'
      },
      body: JSON.stringify(data)
      // body: JSON.stringify(estudianteCurso)
    })

    if (response.ok) {
      setShowModalCalificacion(!showModalCalificacion);
      await mostrarEstudianteCursos();
    }
  }

  const eliminarEstudiante = async (id) => {

    var respuesta = window.confirm("¿Estás seguro de eliminar el elemento?");


    if (!respuesta) {
      return;
    }

    const response = await fetch("api/estudiantes/Eliminar/" + id, {
      method: 'DELETE',

    });
    /**  
    headers: {
      'Content-Type': 'application/json;charset=utf-8'
    },
    body: JSON.stringify(estudiante)
      */


    if (response.ok) {
      await mostrarEstudianteCursos();
    }
  }




  useEffect(() => {
    mostrarEstudianteCursos();
  }, [])





  return (
    <Container>
      <Row className="mt-5">
        <Col sm="12">
          <Card>
            <CardHeader>
              <h5>Lista de cursos del alumno</h5>
            </CardHeader>
            <CardBody>
              <Button size="sm" color="success" onClick={() => abrirModalRegistrarACursos() }>Agregar a curso nuevo</Button>
              <hr></hr>
              <TablaEstudianteClases data={estudianteCursos}
                eliminarEstudiante={eliminarEstudiante}


                showModalCalificacion={showModalCalificacion}
                setShowModalCalificacion={setShowModalCalificacion}
                setEstudianteCursoAEditar={setEstudianteCursoAEditar}

              />
            </CardBody>
          </Card>
        </Col>
      </Row>
      <ModalEstudianteClases showModalAgregarACurso={showModalAgregarACurso}
        setShowModalAgregarACurso={setShowModalAgregarACurso}
        registrarACurso={registrarACurso}

        cursosDisponibles={cursosDisponibles}
        

      />

      <ModalCalificar showModalCalificacion={showModalCalificacion}
        setShowModalCalificacion={setShowModalCalificacion}
        estudianteCursoAEditar={estudianteCursoAEditar}
        setEstudianteCursoAEditar={setEstudianteCursoAEditar}
        editarCalificacion={editarCalificacion}
      />
    </Container>
  );

}

export default CalificacionesComponent;