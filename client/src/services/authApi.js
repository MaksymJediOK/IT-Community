import { createApi } from '@reduxjs/toolkit/query/react'
import { baseQuery } from './baseQuery'


export const authApi = createApi({
	baseQuery: baseQuery,
	endpoints: (builder) => ({
		login: builder.mutation({
			query: (credentials) => ({
				url: '/auth/login',
				method: 'POST',
				body: { ...credentials },
			}),
		}),
		register: builder.mutation({
			query: (credentials) => ({
				url: '/auth/register',
				method: 'POST',
				body: { ...credentials },
			}),
		}),
		isAuth: builder.query({
			query: () => '/auth',
		}),
	}),
})

export const { useLoginMutation, useRegisterMutation, useIsAuthQuery } = authApi
