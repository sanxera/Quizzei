import request from "../utils/request";

export async function login(params) {

  if (!params) return;
  // const response = await request('api/users/login', {
  //   method: 'POST',
  //   data: {
  //     ...params
  //   },
  // });

  let logged = false;

  if (params.email === 'luiz@gmail.com' && params.password === '123456') logged = true;

  return {
    logged,
  };
}

export async function register(params) {
  if (!params) return;
  return request('api/users/create-user', {
    method: 'POST',
    data: {
      ...params
    },
  });
}