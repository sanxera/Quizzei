import request from "../utils/request";

export async function login(params) {
  if (!params) return;
  await request(`/login`, {
    method: 'POST',
    data: {
      ...params
    },
  })
}