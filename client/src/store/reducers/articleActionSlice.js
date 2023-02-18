import { createSlice } from '@reduxjs/toolkit'

const initialState = {
	title: [],
	body: [],
	imageFile: [],
	desc: [],
}

const articleActionSlice = createSlice({
	name: 'ArticleErrors',
	initialState,
	reducers: {
		setErrors: (state, action) => {
			const { Title = [], Body = [], ImageFile = [], Description = [] } = action.payload
			state.title = Title
			state.body = Body
			state.imageFile = ImageFile
			state.desc = Description
		},
	},
})

export const { setErrors } = articleActionSlice.actions
export const articleActionReducer = articleActionSlice.reducer
