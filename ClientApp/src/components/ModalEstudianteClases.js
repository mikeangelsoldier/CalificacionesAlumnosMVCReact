import { Modal, ModalBody, ModalHeader, Form, FormGroup, Label, Input, ModalFooter, Button } from "reactstrap"
import { useState, useEffect } from "react";



const ModalEstudianteClases = ({ showModalAgregarACurso, setShowModalAgregarACurso, registrarACurso, cursosDisponibles }) => {

    const [currentSelectedValue, setCurrentSelectedValue] = useState(null);




    const actualizaDato = (e) => {
        console.log(e.target.name + " : " + e.target.value);

        setCurrentSelectedValue(e.target.value);

    }

    const enviarDatosRegistrarAClase = () => {

        console.log("currentSelectedValue: ", currentSelectedValue);
        if (currentSelectedValue) {
            registrarACurso(currentSelectedValue);
        }
    }


    const cerrarModal = () => {
        setShowModalAgregarACurso(!showModalAgregarACurso);
        // setEstudianteAEditar([]);
    }

    useEffect(() => {



    }, [])



    return (
        <Modal isOpen={showModalAgregarACurso}>
            <ModalHeader>
                Registrar alumno a nuevo curso
            </ModalHeader>
            <ModalBody>
                <Form>
                    <FormGroup>
                        <Label>Curso</Label>

                        <Input defaultValue={currentSelectedValue ? currentSelectedValue : ''} name="cursoId" type="select" onChange={(e) => actualizaDato(e)} >
                            {
                                cursosDisponibles.map(el => <option value={el.id} key={el.id}>{el.nombre}</option>)
                            }
                        </Input>
                    </FormGroup>

                </Form>
            </ModalBody>
            <ModalFooter>
                <Button color="primary" size="sm" onClick={enviarDatosRegistrarAClase} >Guardar</Button>
                <Button color="danger" size="sm" onClick={cerrarModal} >Cerrar</Button>
            </ModalFooter>

        </Modal>
    )
}

export default ModalEstudianteClases;


/*

<!--
                <Button color="danger" size="sm" onClick={() => setShowModalAgregarACurso(!showModalAgregarACurso)} >Cerrar</Button>
                -->

*/