import React from 'react'
import styles from './ArticleDetails.module.scss'
import { Link, useParams } from 'react-router-dom'
import { Container, Grid } from '@mui/material'
import { ItemCard } from './components/ItemCard/ItemCard'
import { AuthorInfo } from './components/AuthorInfo/AuthorInfo'
import { Comments } from './components/Comments/Comments'
import { useGetSingleArticleQuery } from 'services/articleApi'
import { ArticleDetailsSkeleton } from './ArticleDetailsSkeleton'

export const ArticleDetails = () => {
	const { id } = useParams()
	const { data = {}, isLoading } = useGetSingleArticleQuery(id)
	return (
		<Container>
			<div className={styles.crumbs}>
				IT ROOM /{' '}
				<Link to='/articles' className={styles.link}>
					Articles
				</Link>
			</div>
			<Grid container spacing={3}>
				<Grid item xs={8}>
					{isLoading ? <ArticleDetailsSkeleton /> : <ItemCard {...data} />}
					<Comments comments={data.comments} />
				</Grid>
				<Grid item xs={4}>
					<AuthorInfo userName={data.userName} />
				</Grid>
			</Grid>
		</Container>
	)
}
