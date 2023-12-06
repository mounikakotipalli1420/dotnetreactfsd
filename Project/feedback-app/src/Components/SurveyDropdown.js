import React, { useState, useEffect } from 'react';
import axios from 'axios';

const SurveyDropdown = () => {
  const [surveys, setSurveys] = useState([]);

  useEffect(() => {
    const fetchSurveys = async () => {
      try {
        const response = await axios.get('http://localhost:5095/api/Survey');
        console.log(4444,response);
        if (response.statusText=="OK")
        {
          setSurveys(response?.data.$values)
        }
        console.log(5555,surveys);
        if (!response.ok) {
          throw new Error(`API request failed with status ${response.status}`);
        }

        /*const data = await response.json();

        if (Array.isArray(data)) {
          setSurveys(data);
          console.log('Surveys:', data); // Log surveys to the console
        } else {
          throw new Error('Invalid survey data: ' + JSON.stringify(data));
        }*/
      } catch (error) {
        console.error('Error fetching surveys:', error.message);
      }
    };

    fetchSurveys();
  }, []);

  return (
    <div>
      <h2>Select Survey</h2>
      <select>
        {surveys.map((survey) => (
          <option key={survey.id} value={survey.id}>
            {survey.title}
          </option>
        ))}
      </select>
      <div>
        {/* Display surveys on the webpage */}
        <h3>Surveys:</h3>
        <ul>
          {surveys.map((survey) => (
            <li key={survey.id}>{survey.title}</li>
          ))}
        </ul>
      </div>
    </div>
  );
};

export default SurveyDropdown;
