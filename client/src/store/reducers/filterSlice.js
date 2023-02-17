import { createSlice } from '@reduxjs/toolkit'

const initialState = {
	filter: 'nv',
	sort: 'nv',
	tags: [],
	search: '',
}

export const filterSlice = createSlice({
	name: 'filters',
	initialState,
	reducers: {
		setTags: (state, action) => {
			state.tags = action.payload
		},
		setFilter: (state, action) => {
			state.filter = action.payload
		},
		setSort: (state, action) => {
			state.sort = action.payload
		},
		setSearch: (state, action) => {
			state.search = action.payload
		},
	},
})

export const { setTags, setFilter, setSort, setSearch } = filterSlice.actions
export const filterReducer = filterSlice.reducer
