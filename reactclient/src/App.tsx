import './App.css';
import { useEffect } from 'react';
import { Routes, Route } from 'react-router-dom';
import { useDispatch } from 'react-redux';
import { useTypedSelector } from './hooks/useTypedSelector';

import LoginForm from './components/LoginForm';
import Navbar from './components/Navbar';
import Home from './components/Home';
import RegisterForm from './components/RegisterForm';
import History from './components/History';
import { fetchAuth } from './api/authApi';

function App() {
  const {user, error, loading} = useTypedSelector(state => state.authReducer);
  const dispatch = useDispatch();

  useEffect(() => {
    dispatch(fetchAuth())
  }, []);

  return (
    <div className="App">
      <Navbar />

      <main className="form-signin w-100 m-auto">
        <Routes>
          <Route path="/" element={ <Home />} />
          <Route path="/home" element={ <Home /> } />
          <Route path="/login" element={ <LoginForm /> } />
          <Route path="/register" element={ <RegisterForm /> } />
          <Route path="/history" element={ <History /> } />
        </Routes>
      </main>
    </div>
  );
}

export default App;