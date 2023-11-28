import React from 'react';

const Welcome = () => {
  return (
    <div style={styles.container}>
      <h1 style={styles.title}>Welcome to Feedback App</h1>
      <p style={styles.description}>
        We value your feedback! Please login or sign up to get started.
      </p>
    </div>
  );
};

const styles = {
  container: {
    textAlign: 'center',
    marginTop: '50px',
  },
  title: {
    fontSize: '2em',
    fontWeight: 'bold',
    marginBottom: '20px',
  },
  description: {
    fontSize: '1.2em',
    color: '#555',
  },
};

export default Welcome;
