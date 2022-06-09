import { extend } from 'umi-request';

const codeMessage = {
    200: 'The server successfully returned the requested data.',
    201: 'New or modified data is successful.',
    202: 'A request has entered the background queue (asynchronous task).',
    204: 'Delete data successfully.',
    400: 'The request was sent with an error. The server did not perform any operations to create or modify data.',
    401: 'The user does not have permission (token, username, password is incorrect).',
    403: 'User is authorized, but access is forbidden.',
    404: 'The request sent is for a record that does not exist and the server is not operating.',
    406: 'The format of the request is not available.',
    410: 'The requested resource is permanently deleted and will not be obtained again.',
    422: 'When creating an object, a validation error occurred.',
    500: 'The server has an error. Please check the server.',
    502: 'Gateway error.',
    503: 'The service is unavailable, the server is temporarily overloaded or maintained.',
    504: 'The gateway timed out.',
};

const errorHandler = error => {
    const { response = {} } = error;
    const errortext = codeMessage[response.status] || response.statusText;
    const { status, url } = response;

    console.log('Error ', {
        errortext,
        status,
        url
    });
};

const headers = {
    'Content-type': 'application/json',
    'Access-Control-Allow-Credentials': true,
    'Access-Control-Allow-Origin': '*',
    'Access-Control-Allow-Headers': 'x-requested-with',
}

const request = extend({
    maxCache: 10,
    errorHandler,
    credentials: 'include',
    headers,
});


export default request;