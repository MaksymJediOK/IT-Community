import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
import { logOut, setCredentials } from '../store/reducers/authSlice'

const baseQuery = fetchBaseQuery({
	baseUrl: 'https://localhost:7230/api/auth',
	credentials: 'include',
	prepareHeaders: (headers, { getState }) => {
		const token = getState().auth.token
		if (token) {
			headers.set('Authorization', `Bearer ${token}`)
		}
		return headers
	},
})

const baseQueryWithReAuth = async (args, api, extraOptions) => {
	let result = await baseQuery(args, api, extraOptions)

	if (result?.error?.originalStatus === 403) {
		console.log('sending refresh token')
		const refreshResult = await baseQuery('/refresh', api, extraOptions)
		console.log(refreshResult)
		if (refreshResult?.data) {
			const user = api.getState().auth.user
			api.dispatch(setCredentials({ ...refreshResult.data, user }))
			result = await baseQuery(args, api, extraOptions)
		} else {
			api.dispatch(logOut())
		}
	}

	return result
}

export const authApi = createApi({
	baseQuery: baseQueryWithReAuth,
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

export const {useLoginMutation} = authApi

