import { Table, Button } from "reactstrap"

const TablaEstudianteClases = ({ data, setEstudianteCursoAEditar, showModalCalificacion, setShowModalCalificacion, eliminarEstudianteCurso }) => {


    const openModalCalificar = (estudianteCurso) => {
        setEstudianteCursoAEditar(estudianteCurso);
        setShowModalCalificacion(!showModalCalificacion);

    }

    return (
        <Table striped responsive>
            <thead>
                <tr>
                    {/*<th>Id</th>*/}
                    <th>Estudiante</th>
                    <th>Curso</th>
                    <th>Calificación</th>
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
                                <td>{item.estudiante.nombre} {item.estudiante.apellidos}</td>
                                <td>{item.curso.nombre}</td>
                                <td>{item.calificacion ? item.calificacion : '--'}</td>
                                <td>
                                    <Button color="secondary" size="sm" className="me-2" onClick={() => openModalCalificar(item)} >Asignar calificación</Button>
                                    <Button color="danger" size="sm" onClick={() => eliminarEstudianteCurso(item.id)}>Eliminar</Button>
                                </td>
                            </tr>
                        ))
                    )
                }

            </tbody>
        </Table>
    )
}

export default TablaEstudianteClases;
