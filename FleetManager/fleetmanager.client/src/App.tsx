import './App.css';
import { Routes, Route } from "react-router";
import Navbar from './Navbar';
import Home from './routes/Home';
import Employees from './routes/Employees';
import Vehicles from './routes/Vehicles';
import CostsList from './Costs/CostsList';

function App() {
    //get employeeId from local storage as number
    const empId = localStorage.getItem('empId');
    const empIdNumber = empId ? parseInt(empId, 10) : 3;

    return (
        <>
            <Navbar />
            <div >
                <Routes>
                    <Route path="/" element={<Home />} />
                    {empIdNumber === 3 && (<Route path="/employees" element={<Employees />} />)}
                    <Route path="/vehicles" element={<Vehicles />} />
                    <Route path="/costs" element={<CostsList /> } />
                </Routes>
            </div>
        </>
    );
}

export default App;