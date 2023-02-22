import { useIsAuthQuery } from '../services/authApi'

export const useIsAuthorized = () => {
	const { data, isLoading } = useIsAuthQuery()
	if (!isLoading) {
		return !!data?.isAuthorized
	}
	return false
}
