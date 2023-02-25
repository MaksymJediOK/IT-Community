import jwtDecode from 'jwt-decode'

export const getDecodedName = () => {
	const token = localStorage.getItem('token')
	const decoded = jwtDecode(token)
	const { Name } = decoded
	return Name
}
