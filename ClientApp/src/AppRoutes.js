import CalificacionesComponent from "./components/CalificacionesComponent";
import EstudiantesComponent from "./components/EstudiantesComponent";


const AppRoutes = [
  {
    index: true,
    element: <EstudiantesComponent />
  },
  {
    path: '/estudiantes/:idEstudiante/calificaciones',
    element: <CalificacionesComponent />
  }/*,
  {
    path: '/fetch-data',
    element: <FetchData />
  }*/
];

export default AppRoutes;
