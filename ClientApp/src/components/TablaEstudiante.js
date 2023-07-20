import { Table, Button } from "reactstrap"
import { Outlet, Link } from "react-router-dom";

const TablaEstudiante = ({ data, setEstudianteAEditar, showModalEstudiante, setShowModalEstudiante, eliminarEstudiante }) => {

    const enviarDatos = (estudiante) => {
        setEstudianteAEditar(estudiante);
        setShowModalEstudiante(!showModalEstudiante);

    }


    return (
        <Table striped responsive>
            <thead>
                <tr>
                    {/*<th>Id</th>*/}
                    <th>Nombre</th>
                    <th>Apellidos</th>
                    <th>Total cursos</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
                {
                    (data.length < 1) ? (
                        <tr>
                            <td colSpan="4">Sin registros</td>
                        </tr>
                    ) : (
                        data.map((item) => (
                            <tr key={item.id}>
                                {/*<td>{item.id}</td>*/}
                                <td>{item.nombre}</td>
                                <td>{item.apellidos}</td>
                                <td>{item.estudiantesCursos.length > 0 ? item.estudiantesCursos.length : 0}</td>
                                <td>
                                    <Button color="secondary" size="sm" className="me-2" tag={Link} to={"/estudiantes/" + item.id + "/calificaciones"} >Calificaciones</Button>
                                    <Button color="primary" size="sm" className="me-2" onClick={() => enviarDatos(item)} >Editar</Button>
                                    <Button color="danger" size="sm" onClick={() => eliminarEstudiante(item.id)}>Eliminar</Button>
                                </td>
                            </tr>
                        ))
                    )
                }

            </tbody>
        </Table>
    )
}

export default TablaEstudiante;
