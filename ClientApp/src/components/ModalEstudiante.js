import { Modal, ModalBody, ModalHeader, Form, FormGroup, Label, Input, ModalFooter, Button } from "reactstrap"
import { useState, useEffect } from "react";

const modeloDefaultEstudiante = {
    id: 0,
    nombre: '',
    correo: '',
    telefono: ''
}

const ModalEstudiante = ({ showModalEstudiante, setShowModalEstudiante, setEstudianteAEditar, estudianteAEditar, guardarEstudiante, editarEstudiante }) => {

    const [currentEstudianteData, setCurrentEstudianteData] = useState(modeloDefaultEstudiante);

    const actualizaDato = (e) => {
        console.log(e.target.name + " : " + e.target.value);

        setCurrentEstudianteData({
            ...currentEstudianteData, [e.target.name]: e.target.value
        });
    }

    const enviarDatos = () => {
        if (currentEstudianteData.id == 0) {
            guardarEstudiante(currentEstudianteData);

        } else {
            editarEstudiante(currentEstudianteData); //
        }
    }

    useEffect(() => {
        if (estudianteAEditar != null) {
            setCurrentEstudianteData(estudianteAEditar);
        } else {
            setCurrentEstudianteData(modeloDefaultEstudiante);
        }

        // setCurrentEstudianteData(modeloDefaultEstudiante);
    }, [estudianteAEditar])

    const cerrarModal = () => {
        setShowModalEstudiante(!showModalEstudiante);
        setEstudianteAEditar(null);
    }

    return (
        <Modal isOpen={showModalEstudiante}>
            <ModalHeader>
                {currentEstudianteData.id == 0 ? "Nuevo estudiante" : "Editar estudiante"}
            </ModalHeader>
            <ModalBody>
                <Form>
                    <FormGroup>
                        <Label>Nombre</Label>
                        <Input name="nombre" onChange={(e) => actualizaDato(e)} value={currentEstudianteData.nombre} />
                    </FormGroup>

                    <FormGroup>
                        <Label>Apellidos</Label>
                        <Input name="apellidos" onChange={(e) => actualizaDato(e)} value={currentEstudianteData.apellidos} />
                    </FormGroup>
                </Form>
            </ModalBody>
            <ModalFooter>
                <Button color="primary" size="sm" onClick={enviarDatos} >Guardar</Button>
                <Button color="danger" size="sm" onClick={cerrarModal} >Cerrar</Button>
            </ModalFooter>

        </Modal>
    )
}

export default ModalEstudiante;


/*

<!--
                <Button color="danger" size="sm" onClick={() => setShowModalEstudiante(!showModalEstudiante)} >Cerrar</Button>
                -->

*/