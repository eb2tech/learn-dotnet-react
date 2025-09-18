import { useEffect, useState } from 'react';
import { type WeatherData } from './generated/weather';
import { getWeatherForecast } from './services/weatherService';
import './App.css';

function AppRpc() {
  const [forecasts, setForecasts] = useState<WeatherData[]>([]);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const data = await getWeatherForecast();
        setForecasts(data);
      } catch (error) {
        console.error('Error fetching weather data:', error);
      }
    };
    fetchData();
  }, []);

  return (
    <>
      <h1>Weather forecast (gRPC)</h1>
      <table className="table">
        <thead>
          <tr>
            <th>Date</th>
            <th>Temp. (C)</th>
            <th>Temp. (F)</th>
            <th>Summary</th>
          </tr>
        </thead>
        <tbody>
          {forecasts.map((forecast) => (
            <tr key={forecast.date}>
              <td>{forecast.date}</td>
              <td>{forecast.temperatureC}</td>
              <td>{forecast.temperatureF}</td>
              <td>{forecast.summary}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </>
  );
}

export default AppRpc;