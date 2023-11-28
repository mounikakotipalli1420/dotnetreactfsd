import React, { useState } from 'react';
import Welcome from './Components/Welcome';
import Login from './Components/Login';
import RegisterUser from './Components/RegisterUser';
import Survey from './Components/Survey';


function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const [isLoginSelected, setIsLoginSelected] = useState(false);
  const [isRegisterSelected, setIsRegisterSelected] = useState(false);

  const handleLoginSelect = () => {
    setIsLoginSelected(true);
    setIsRegisterSelected(false);
  };

  const handleRegisterSelect = () => {
    setIsLoginSelected(false);
    setIsRegisterSelected(true);
  };

  const handleLogin = () => {
    // Implement your login logic
    setIsLoggedIn(true);
    setIsLoginSelected(false);
    setIsRegisterSelected(false);
  };

  const handleRegister = () => {
    // Implement your register logic
    setIsLoggedIn(true);
    setIsLoginSelected(false);
    setIsRegisterSelected(false);
  };

  return (
    <div className="App">
      <Welcome />
  
      {!isLoggedIn && !isLoginSelected && !isRegisterSelected && (
        <div>
          <button onClick={handleLoginSelect}>Login</button>
          <div style={{ marginBottom: '10px' }}></div>
          <button onClick={handleRegisterSelect}>Register</button>
        </div>
      )}
  
      {isLoginSelected && !isLoggedIn && (
        <Login onLogin={handleLogin} />
      )}
  
      {isRegisterSelected && !isLoggedIn && (
        <RegisterUser onRegister={handleRegister} />
      )}
  
      {isLoggedIn && (
        <div>
          {/* Your survey component goes here */}
          <Survey />
        </div>
      )}
      
      
    </div>
  );
      }
  export default App;