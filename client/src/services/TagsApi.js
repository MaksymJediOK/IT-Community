import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'

export const TagsApi = createApi({
	reducerPath: 'tags',
	baseQuery: fetchBaseQuery({ baseUrl: 'https://localhost:7230/api' }),
	endpoints: (build) => ({
		getAllTags: build.query({
			query: () => '/tag',
		}),
	}),
})

export const { useGetAllTagsQuery } = TagsApi
