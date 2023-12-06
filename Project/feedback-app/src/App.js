import React, { useState } from 'react';
import { BrowserRouter as Router, Routes, Route, Link, Navigate } from 'react-router-dom';
import Welcome from './Components/Welcome';
import Login from './Components/Login';
import RegisterUser from './Components/RegisterUser';
import SurveyPage from './Components/SurveyPage';
import CreateSurvey from './Components/CreateSurvey';

function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  return (
    <Router>
      <div className="App">
        <nav>
          <ul>
            <li>
              <Link to="/">Home</Link>
            </li>
            {isLoggedIn ? (
              <>
                <li>
                  <Link to="/surveys">Surveys</Link>
                </li>
                <li>
                  <Link to="/create-survey">Create Survey</Link>
                </li>
                
              </>
            ) : (
              <>
                <li>
                  <Link to="/login">Login</Link>
                </li>
                <li>
                  <Link to="/register">Register</Link>
                </li>
              </>
            )}
          </ul>
        </nav>

        <hr />

        <Routes>
          <Route path="/" element={<Welcome />} />
          <Route
            path="/login"
            element={
              !isLoggedIn ? (
                <Login onLogin={() => setIsLoggedIn(true)} />
              ) : (
                <Navigate to="/surveys" />
              )
            }
          />
          <Route
            path="/register"
            element={
              !isLoggedIn ? (
                <RegisterUser onRegister={() => setIsLoggedIn(true)} />
              ) : (
                <Navigate to="/surveys" />
              )
            }
          />
          <Route
            path="/surveys"
            element={isLoggedIn ? <SurveyPage /> : <Navigate to="/" />}
          />
          <Route path="/create-survey" element={isLoggedIn ? <CreateSurvey /> : <Navigate to="/" />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;
