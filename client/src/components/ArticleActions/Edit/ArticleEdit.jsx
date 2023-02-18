import React, { useEffect, useState } from 'react'
import styles from './ArticleEdit.module.scss'
import { Container, Grid, Box, TextField, Button, TextareaAutosize, Stack } from '@mui/material'
import Select from 'react-select'
import { useForm, Controller } from 'react-hook-form'
import { useEditArticleMutation, useGetSingleArticleQuery } from '../../../services/articleApi'
import { useNavigate, useParams } from 'react-router-dom'
import { setErrors } from '../../../store/reducers/articleActionSlice'
import { useDispatch, useSelector } from 'react-redux'
import { ArticleErrorMsg } from '../../UI/ErrorMsg/ArticleErrorMsg'
import { useGetOptions } from '../../../hooks/useGetOptions'
import { ArticleEditSkeleton } from './ArticleEditSkeleton'

export const ArticleEdit = () => {
	const { id } = useParams()
	const dispatch = useDispatch()
	const navigate = useNavigate()
	const createErrors = useSelector((state) => state.articleErrors)
	const [file, setFile] = useState(null)
	const { data, isLoading } = useGetSingleArticleQuery(id)
	const [EditArticle] = useEditArticleMutation()

	const { tagsOptions, isTagsLoading } = useGetOptions()
	const selectFile = (e) => {
		setFile(e.target.files[0])
	}
	const defaultOptions = () => {
		if (data?.tags.length) {
			return tagsOptions.filter((el) => {
				return data?.tags.some((tag) => {
					return el.value === tag.id
				})
			})
		}
	}
	const { handleSubmit, control, setValue } = useForm({
		defaultValues: {
			title: '',
			desc: '',
			body: '',
		},
	})

	const handleOnSubmit = (article) => {
		const { title, desc, body, options = [] } = article
		const editBody = new FormData()
		editBody.append('Title', title)
		editBody.append('Description', desc)
		editBody.append('Body', body)
		if (file != null) {
			editBody.append('ImageFile', file)
		}
		options.forEach((item) => {
			editBody.append('TagsId', `${item.value}`)
		})
		editBody.append('ForumId', `${1}`)
		EditArticle({ id, editBody })
			.unwrap()
			.then(() => navigate('/articles'))
			.catch((error) => {
				dispatch(setErrors(error.data?.errors))
			})
	}

	useEffect(() => {
		if (!isLoading) {
			setValue('title', data.title)
			setValue('desc', data.description)
			setValue('body', data.body)
		}
	}, [setValue, isLoading])

	return (
		<Container sx={{ marginTop: '32px' }}>
			{isLoading ? (
				<ArticleEditSkeleton />
			) : (
				<Box component='form' onSubmit={handleSubmit(handleOnSubmit)}>
					<Grid container spacing={3}>
						<Grid item xs={8}>
							<div className={styles.title}>Editing current article</div>
							<div className={styles.create_container}>
								<Box sx={{ margin: '24px 0 0 24px' }}>
									<Controller
										control={control}
										name='title'
										render={({ field }) => (
											<TextField
												{...field}
												label='Title'
												variant='standard'
												sx={{ width: '600px' }}
												inputProps={{ style: { fontSize: '32px' } }}
												InputLabelProps={{
													style: { fontSize: '32px', fontWeight: '900' },
												}}
											/>
										)}
									/>
									{createErrors.title.length ? (
										<ArticleErrorMsg>{createErrors.title[0]}</ArticleErrorMsg>
									) : (
										''
									)}
									<Controller
										control={control}
										name='desc'
										render={({ field }) => (
											<TextField
												{...field}
												label='About'
												variant='standard'
												helperText='What your story is about in a short sentence'
												sx={{ width: '400px', margin: '12px 0 10px 0' }}
												inputProps={{ style: { fontSize: '20px' } }}
												InputLabelProps={{
													style: {
														fontSize: '20px',
														fontWeight: '500',
														opacity: '0.5',
														letterSpacing: '0.15px',
														paddingBottom: '5px',
													},
												}}
											/>
										)}
									/>
									{createErrors.desc.length ? (
										<ArticleErrorMsg>{createErrors.desc[0]}</ArticleErrorMsg>
									) : (
										''
									)}
									<Stack sx={{ m: '10px 0 15px' }}>
										<div className={styles.upload_text}>
											Upload thumbnail for your article
										</div>
										<input type='file' onChange={selectFile} />
										{/*<img className={styles.file_img} src={data?.imageSrc} alt='' />*/}
									</Stack>
									{createErrors.imageFile.length ? (
										<ArticleErrorMsg>{createErrors.imageFile[0]}</ArticleErrorMsg>
									) : (
										''
									)}
									<Controller
										control={control}
										name='body'
										render={({ field }) => (
											<TextareaAutosize
												{...field}
												minRows={3}
												style={{
													width: '600px',
													fontSize: '20px',
													fontWeight: '500',
													opacity: '0.5',
													letterSpacing: '0.15px',
												}}
												aria-label='Body'
												placeholder='Tell the world about your investigation'
											/>
										)}
									/>
									{createErrors.body.length ? (
										<ArticleErrorMsg>{createErrors.body[0]}</ArticleErrorMsg>
									) : (
										''
									)}
								</Box>
							</div>
						</Grid>
						<Grid item xs={4}>
							<div className={styles.title}>Configure</div>
							<div className={styles.help_text}>
								Help us sort your story in the right categories
							</div>
							{isTagsLoading ? (
								''
							) : (
								<Controller
									control={control}
									name='options'
									defaultValue={defaultOptions()}
									render={({ field }) => (
										<Select options={tagsOptions} {...field} isMulti />
									)}
								/>
							)}

							<Button
								type='submit'
								fullWidth
								variant='outlined'
								size='large'
								sx={{ mt: '24px' }}
							>
								{' '}
								PUBLISH{' '}
							</Button>
						</Grid>
					</Grid>
				</Box>
			)}
		</Container>
	)
}
