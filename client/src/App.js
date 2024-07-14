
import './App.css';
import AppRoutes from "./components/AppRoutes";
import { BrowserRouter } from "react-router-dom";
import { PrimeReactProvider, PrimeReactContext } from 'primereact/api';
function App() {
  return (
    <PrimeReactProvider>
      <BrowserRouter>
        <AppRoutes></AppRoutes>
      </BrowserRouter>
    </PrimeReactProvider>
  )
}

export default App;
