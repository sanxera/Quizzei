import axios from "axios";
import { setAuthority } from "../utils/auth";

const { REACT_APP_QUIZZEI_BACKEND_URL } = process.env

export async function login(params) {
  if (!params) return;
  const request = axios.create({
    baseURL: 'https://localhost:44343',
    headers: {
      'Content-type': 'application/json',
      'Access-Control-Allow-Credentials': true,
      'Access-Control-Allow-Origin': '*',
      'Access-Control-Allow-Headers': 'x-requested-with',
    }
  });

  const response = await request('api/users/login', {
    method: 'POST',
    data: {
      ...params
    },
  });
  // const response = { data: { token: '"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhZDk1NzRhMC01MTkyLTQ3MmMtYWM1NS05ZDc4ZmU2NDExYzgiLCJlbWFpbCI6Imx1aXppbjEyM0BnbWFpbC5jb20iLCJqdGkiOiIyMjU5M2VjMy0xZTlmLTQwYTctODUwYi02NzY0ZGYyZGM5YzUiLCJuYmYiOjE2NTQ2Mzg5MDgsImlhdCI6MTY1NDYzODkwOCwiZXhwIjoxNjU0NjQ2MTA4LCJpc3MiOiJRdWl6emVpSWRlbnRpdHkiLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdCJ9.EV4rYiA8j16BePL3iUtqyTeQG4yMf7vPCWuMinsz6zI' } }
  if (!response.data || !response.data.token) return false;
  await setAuthority(response.data);
  return true;
}

export async function register(params) {
  if (!params) return;
  const request = axios.create({
    baseURL: 'https://localhost:44343',
    headers: {
      'Content-type': 'application/json',
      'Access-Control-Allow-Credentials': true,
      'Access-Control-Allow-Origin': '*',
      'Access-Control-Allow-Headers': 'x-requested-with',
    }
  });
  const response = await request('api/users/create-user', {
    method: 'POST',
    data: {
      ...params
    },
  });

  return response.data;
  // return { created: true };
}