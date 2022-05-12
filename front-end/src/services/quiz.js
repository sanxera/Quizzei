import request from "../utils/request";

export async function create(params) {
  const response = await request('api/quiz/create', {
    method: 'POST',
    data: {
      ...params
    },
  });
  return response;
}