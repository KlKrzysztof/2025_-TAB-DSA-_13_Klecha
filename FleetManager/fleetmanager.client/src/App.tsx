import './App.css';
import { Routes, Route } from "react-router";
import Navbar from './Navbar';
import Home from './routes/Home';
import Employees from './routes/Employees';
import Vehicles from './routes/Vehicles';
import { Addresses } from './Addresses';


function App() {
    return (
        <>
            <Navbar />
            <div >
                <Routes>
                    <Route path="/" element={<Home />} />
                    <Route path="/employees" element={<Employees />} />
                    < Route path = "/vehicles" element = {< Vehicles />} />
                    < Route path = "/addresses" element = {< Addresses />} />
                </Routes>
            </div>
        </>
    );
}

export default App;