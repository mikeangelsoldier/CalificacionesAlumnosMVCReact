import { Modal, ModalBody, ModalHeader, Form, FormGroup, Label, Input, ModalFooter, Button } from "reactstrap"
import { useState, useEffect } from "react";


const ModalCalificar = ({ showModalCalificacion, setShowModalCalificacion, setEstudianteCursoAEditar, estudianteCursoAEditar, editarCalificacion }) => {

    const [currentEstudianteCursoData, setCurrentEstudianteCursoData] = useState(null);

    const actualizaDato = (e) => {
        console.log(e.target.name + " : " + e.target.value);

        setCurrentEstudianteCursoData({
            ...currentEstudianteCursoData, [e.target.name]: e.target.value
        });
    }

    const enviarCalificacion = () => {
        editarCalificacion(currentEstudianteCursoData); //
    }

    useEffect(() => {

        setCurrentEstudianteCursoData(estudianteCursoAEditar);


        // setCurrentEstudianteCursoData(modeloDefaultEstudiante);
    }, [estudianteCursoAEditar])

    const cerrarModal = () => {
        setShowModalCalificacion(!showModalCalificacion);
        setEstudianteCursoAEditar(null);
    }

    return (
        <Modal isOpen={showModalCalificacion}>
            <ModalHeader>
                Calificar Alumno en el curso: {currentEstudianteCursoData ? currentEstudianteCursoData.curso.nombre : ''}
            </ModalHeader>
            <ModalBody>
                <Form>
                    <FormGroup>
                        <Label>Calificación</Label>
                        <Input name="calificacion" onChange={(e) => actualizaDato(e)} value={currentEstudianteCursoData ? currentEstudianteCursoData.calificacion : ''} />
                    </FormGroup>

                </Form>
            </ModalBody>
            <ModalFooter>
                <Button color="primary" size="sm" onClick={enviarCalificacion} >Enviar Califcacion</Button>
                <Button color="danger" size="sm" onClick={cerrarModal} >Cerrar</Button>
            </ModalFooter>

        </Modal>
    )
}

export default ModalCalificar;
