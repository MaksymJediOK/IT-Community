import { fetchBaseQuery } from '@reduxjs/toolkit/dist/query/react'

const baseQuery = fetchBaseQuery({
	baseUrl: process.env.REACT_APP_API_URL,
	prepareHeaders: (headers) => {
		const token = localStorage.getItem('token')
		if (token) {
			headers.set('Authorization', `Bearer ${token}`)
		}
		return headers
	},
})

export { baseQuery }
