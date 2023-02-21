import { useIsAuthQuery } from '../services/authApi'

export const useIsAuthorized = () => {
	const { data, isLoading } = useIsAuthQuery()
	if (!isLoading) {
		const { isAuthorized } = data
		return isAuthorized
	}
	return false
}
