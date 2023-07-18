import { Button, Col, Row } from 'reactstrap';

const PaginationComponent = ({ currentPage, totalPages, handlePagina }) => {
  return (
    <Row className="pagination-occ justify-content-center align-items-center">
      <Col xs="auto">
        <Button
          className="prev-button-occ"
          onClick={() => handlePagina(currentPage - 1)}
          disabled={!(currentPage - 1)}
        >
          {currentPage - 1 === 0 ? "No hay página previa" : currentPage - 1}
        </Button>
      </Col>
      <Col xs="auto">
        <p>
          {currentPage} de {totalPages}
        </p>
      </Col>
      <Col xs="auto">
        <Button
          className="next-button-occ"
          onClick={() => handlePagina(currentPage + 1)}
          disabled={currentPage + 1 > totalPages}
        >
          {currentPage + 1 > totalPages
            ? "No hay más páginas por mostrar"
            : currentPage + 1}
        </Button>
      </Col>
    </Row>
  );
};

export default PaginationComponent;
