export function getAuthority(str) {
  const authorityString =
    typeof str === 'undefined' ? localStorage.getItem('quizzei-authority') : str;
  let authority;
  try {
    authority = JSON.parse(authorityString);
  } catch (e) {
    authority = authorityString;
  }
  if (typeof authority === 'string') {
    return [authority];
  }

  if (!authority) {
    return ['GUEST'];
  }
  return authority.username && authority.password;
}
export function setAuthority(authority) {
  const proAuthority = typeof authority === 'string' ? [authority] : authority;
  return localStorage.setItem('quizzei-authority', JSON.stringify(proAuthority));
}
