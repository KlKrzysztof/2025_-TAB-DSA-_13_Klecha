import './App.css';
import { Routes, Route } from "react-router";
import Home from './routes/Home';
import Employees from './routes/Employees';


function App() {
    return (
        <>
            <nav className="navbar navbar-expand-lg navbar-light bg-light">
                <a className="navbar-brand" href="/">Fleet Manager</a>
                <div id="navLinks">
                    <a className="nav-link active" aria-current="page" href="/">Home</a>
                    <a className="nav-link" href="/employees">Employees</a>
                </div>
            </nav>
            <div >
                <Routes>
                    <Route path="/" element={<Home />} />
                    <Route path="/employees" element={<Employees />} />
                </Routes>
            </div>
        </>
    );
}

export default App;