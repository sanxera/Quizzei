import request from '../utils/request';
import { getAuthority, setAuthority } from "../utils/auth";

const { REACT_APP_ENVIRONMENT } = process.env
const isEnvironmentDevelopment = REACT_APP_ENVIRONMENT === 'DEVELOPMENT';

export async function login(params) {
  let response;
  switch (isEnvironmentDevelopment) {
    case true:
      response = {
        data: {
          token: '"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhZDk1NzRhMC01MTkyLTQ3MmMtYWM1NS05ZDc4ZmU2NDExYzgiLCJlbWFpbCI6Imx1aXppbjEyM0BnbWFpbC5jb20iLCJqdGkiOiIyMjU5M2VjMy0xZTlmLTQwYTctODUwYi02NzY0ZGYyZGM5YzUiLCJuYmYiOjE2NTQ2Mzg5MDgsImlhdCI6MTY1NDYzODkwOCwiZXhwIjoxNjU0NjQ2MTA4LCJpc3MiOiJRdWl6emVpSWRlbnRpdHkiLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdCJ9.EV4rYiA8j16BePL3iUtqyTeQG4yMf7vPCWuMinsz6zI',
          isLogged: true,
        }
      };
      break;

    default:
      if (!params) return;
      response = await request('api/users/login', {
        method: 'POST',
        data: {
          ...params
        },
      });
      break;
  }

  const { data } = response;
  if (!data || !data.token || !data.isLogged) return false;
  await setAuthority(response.data);
  return true;
}

export async function register(params) {
  if (isEnvironmentDevelopment) return { created: true };

  if (!params) return;
  const response = await request('api/users/create-user', {
    method: 'POST',
    data: {
      ...params
    },
  });

  return response.data;
}

export async function verifiedRequest() {
  if (isEnvironmentDevelopment) return { created: true };

  const auth = getAuthority();
  const response = await request('api/users/create-user', {
    method: 'POST',
    headers: {
      Authorization: `Bearer ${auth.token}`
    },
  });

  return response.data;
}