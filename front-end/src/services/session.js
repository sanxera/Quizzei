import request from "../utils/request";
import { setAuthority } from "../utils/auth";

const { REACT_APP_QUIZZEI_BACKEND_URL_PORT } = process.env

export async function login(params) {
  if (!params) return;

  const response = await request(`${REACT_APP_QUIZZEI_BACKEND_URL_PORT}/api/users/login`, {
    method: 'POST',
    data: {
      ...params
    },
  });
  // const response = { token: '"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhZDk1NzRhMC01MTkyLTQ3MmMtYWM1NS05ZDc4ZmU2NDExYzgiLCJlbWFpbCI6Imx1aXppbjEyM0BnbWFpbC5jb20iLCJqdGkiOiIyMjU5M2VjMy0xZTlmLTQwYTctODUwYi02NzY0ZGYyZGM5YzUiLCJuYmYiOjE2NTQ2Mzg5MDgsImlhdCI6MTY1NDYzODkwOCwiZXhwIjoxNjU0NjQ2MTA4LCJpc3MiOiJRdWl6emVpSWRlbnRpdHkiLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdCJ9.EV4rYiA8j16BePL3iUtqyTeQG4yMf7vPCWuMinsz6zI' }
  if (!response || !response.token) return false;
  await setAuthority(response);
  return true;
}

export function register(params) {
  if (!params) return;
  return request(`${REACT_APP_QUIZZEI_BACKEND_URL_PORT}/api/users/create-user`, {
    method: 'POST',
    data: {
      ...params
    },
  });

  // return { created: true };
}