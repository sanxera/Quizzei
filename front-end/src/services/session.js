import request from "../utils/request";

export async function login(params) {
  
  if (!params) return;
  const response = await request('api/users/login', {
    method: 'POST',
    data: {
      ...params
    },
  });

  return response;
}

export async function register(params) {
  if (!params) return;
  return request('api/users/register', {
    method: 'POST',
    data: {
      ...params
    },
  });
}