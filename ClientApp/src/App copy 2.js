import { useState, useEffect } from 'react';
import { Col, Container, Row, Card, CardHeader, CardBody, Button } from "reactstrap"
import TablaEstudiante from "./components/TablaEstudiante";
import ModalEstudiante from './components/ModalEstudiante';


const App = () => {

  const [estudiantes, setEstudiantes] = useState([]);
  const [showModalEstudiante, setShowModalEstudiante] = useState(false);
  const [estudianteAEditar, setEstudianteAEditar] = useState(null);


  const mostrarEstudiantes = async () => {
    const response = await fetch("api/estudiantes/Lista");

    if (response.ok) {
      const data = await response.json();

      setEstudiantes(data);

    } else {
      console.log("Error en los datos de la lista");
    }
  }

  useEffect(() => {
    mostrarEstudiantes();
  }, [])


  const guardarEstudiante = async (estudiante) => {
    const response = await fetch("api/estudiantes/Guardar", {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json;charset=utf-8'
      },
      body: JSON.stringify(estudiante)
    })

    if (response.ok) {
      setShowModalEstudiante(!showModalEstudiante);
      mostrarEstudiantes();
    }
  }

  const editarEstudiante = async (estudiante) => {
    const response = await fetch("api/estudiantes/Editar", {
      method: 'PUT',
      headers: {
        'Content-Type': 'application/json;charset=utf-8'
      },
      body: JSON.stringify(estudiante)
    })

    if (response.ok) {
      setShowModalEstudiante(!showModalEstudiante);
      mostrarEstudiantes();
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
      mostrarEstudiantes();
    }
  }

  const goToCalificaciones = async () => {
    console.log("Ir a vista calificaciones");
  }

  return (
    <Container>
      <Row className="mt-5">
        <Col sm="12">
          <Card>
            <CardHeader>
              <h5>Lista de estudiantes</h5>
            </CardHeader>
            <CardBody>
              <Button size="sm" color="success" onClick={() => setShowModalEstudiante(!showModalEstudiante)}>Nuevo Estudiante</Button>
              <hr></hr>
              <TablaEstudiante data={estudiantes}
                setEstudianteAEditar={setEstudianteAEditar}
                showModalEstudiante={showModalEstudiante}
                setShowModalEstudiante={setShowModalEstudiante}
                eliminarEstudiante={eliminarEstudiante}

                goToCalificaciones={goToCalificaciones}
              />
            </CardBody>
          </Card>
        </Col>
      </Row>
      <ModalEstudiante showModalEstudiante={showModalEstudiante}
        setShowModalEstudiante={setShowModalEstudiante}
        guardarEstudiante={guardarEstudiante}
        estudianteAEditar={estudianteAEditar}
        setEstudianteAEditar={setEstudianteAEditar}
        editarEstudiante={editarEstudiante}
      />
    </Container>
  );

}

export default App;