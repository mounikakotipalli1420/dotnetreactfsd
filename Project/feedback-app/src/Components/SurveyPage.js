import React, { useState, useEffect } from 'react';
import SurveyDropdown from './SurveyDropdown';

function SurveyPage() {
  const [surveys, setSurveys] = useState([]);
  const [selectedSurvey, setSelectedSurvey] = useState('');

  useEffect(() => {
    // Fetch surveys from your API or data source
    const fetchSurveys = async () => {
      try {
        const response = await fetch('http://localhost:5095/api/Survey'); // Replace with your API endpoint
        const data = await response.json();
        setSurveys(data); // Assuming your API response is an array of surveys
      } catch (error) {
        console.error('Error fetching surveys:', error);
      }
    };

    fetchSurveys();
  }, []); // The empty dependency array ensures that this effect runs once when the component mounts

  const handleSelectSurvey = (surveyId) => {
    setSelectedSurvey(surveyId);
  };

  return (
    <div>
      <h2>Surveys</h2>
      <SurveyDropdown surveys={surveys} onSelectSurvey={handleSelectSurvey} />

      {/* Display selected survey or other content based on your requirements */}
      {selectedSurvey && <p>Selected Survey: {selectedSurvey}</p>}
    </div>
  );
}

export default SurveyPage;
