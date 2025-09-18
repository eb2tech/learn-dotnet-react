import { WeatherServiceClientImpl, type WeatherRequest, type WeatherResponse } from "../generated/weather";

// Create an RPC implementation that uses fetch
const rpc = {
  async request(
    service: string,
    method: string,
    data: Uint8Array
  ): Promise<Uint8Array> {
    const response = await fetch(`http://localhost:7214/${service}/${method}`, {
      method: 'POST',
      body: data,
      headers: {
        'Content-Type': 'application/x-protobuf'
      }
    });
    if (!response.ok) throw new Error(response.statusText);
    const buffer = await response.arrayBuffer();
    return new Uint8Array(buffer);
  }
};

const client = new WeatherServiceClientImpl(rpc);

export const getWeatherForecast = async () => {
  const request: WeatherRequest = {};
  const response: WeatherResponse = await client.GetWeatherForecast(request);
  return response.forecasts;
};