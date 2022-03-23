export function getAuthority() {
  const authorityString = localStorage.getItem('quizzei-authority');
  let authority;
  try {
    authority = JSON.parse(authorityString);
  } catch (e) {
    authority = authorityString;
  }
  return authority;
}
export function setAuthority(authority) {
  return localStorage.setItem('quizzei-authority', JSON.stringify(authority));
}
