import { authApi } from '../../services/authApi'

export const authApiSlice = authApi.injectEndpoints({
	endpoints: (builder) => ({
		login: builder.mutation({
			query: (credentials) => ({
				url: '/login',
				method: 'POST',
				body: { ...credentials },
			}),
		}),
	}),
})


