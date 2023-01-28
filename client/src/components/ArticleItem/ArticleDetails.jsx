import React from 'react'
import styles from './ArticleDetails.module.scss'
import { useParams } from 'react-router-dom'
import { Container, Grid } from '@mui/material'
import { ItemCard } from './components/ItemCard/ItemCard'
import { AuthorInfo } from './components/AuthorInfo/AuthorInfo'
import { Comments } from './components/Comments/Comments'
import { useGetArticlesListQuery } from '../../services/articleApi'
import { ArticleDetailsSkeleton } from './ArticleDetailsSkeleton'

export const ArticleDetails = () => {
	const { id } = useParams()
	const { data = [], isLoading } = useGetArticlesListQuery()
	return (
		<Container>
			<div className={styles.crumbs}>IT ROOM / Articles</div>
			<Grid container spacing={3}>
				<Grid item xs={8}>
					{isLoading ? <ArticleDetailsSkeleton /> : <ItemCard {...data[0]} />}
					<Comments />
				</Grid>
				<Grid item xs={4}>
					<AuthorInfo />
				</Grid>
			</Grid>
		</Container>
	)
}
//ToDo rebuild when specific endpoint would be ready
