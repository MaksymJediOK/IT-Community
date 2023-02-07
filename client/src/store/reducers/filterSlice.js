import { createSlice } from '@reduxjs/toolkit'

const initialState = {
	filter: '',
	sort: '',
	tags: [],
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
	},
})

export const { setTags, setFilter, setSort } = filterSlice.actions
export const filterReducer = filterSlice.reducer
