import { toast } from 'react-toastify';

export const notification = ({ status = 'success', position = 'top-right', message = '' }) => {
  return toast[status](message, {
    position,
    autoClose: 3000,
    theme: 'colored',
    hideProgressBar: false,
    closeOnClick: true,
    pauseOnHover: false,
    progress: undefined,
  })
}