import './App.css';
import LoginForm from './components/LoginForm';
import Navbar from './components/Navbar';
import { Routes, Route } from 'react-router-dom'
import Home from './components/Home';
import RegisterForm from './components/RegisterForm';

function App() {
  return (
    <div className="App">
      <Navbar />

      <main className="form-signin w-100 m-auto">
        <Routes>
          <Route path="/" element={ <Home />} />
          <Route path="/home" element={ <Home /> } />
          <Route path="/login" element={ <LoginForm /> } />
          <Route path="/register" element={ <RegisterForm /> } />
        </Routes>
      </main>
    </div>
  );
}

export default App;