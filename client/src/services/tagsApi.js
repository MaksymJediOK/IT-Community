import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'

export const tagsApi = createApi({
	reducerPath: 'tags',
	baseQuery: fetchBaseQuery({ baseUrl: process.env.REACT_APP_API_URL }),
	endpoints: (build) => ({
		getAllTags: build.query({
			query: () => '/tag',
		}),
	}),
})

export const { useGetAllTagsQuery } = tagsApi
