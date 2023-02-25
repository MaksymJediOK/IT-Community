import React from 'react'
import { Container, Grid } from '@mui/material'
import { useGetBookmarkedArticlesQuery } from '../../../../services/bookmarkApi'
import { ArticlePreview } from '../../../../components/ArticlePreview/ArticlePreview'
import BookmarkIcon from '@mui/icons-material/Bookmark'

export const Favorites = () => {
	const { data, isLoading } = useGetBookmarkedArticlesQuery()
	return (
		<Container>
			<Grid container spacing={2} sx={{ mt: '25px', ml: '-10px' }}>
				<Grid item xs={8}>
					<Grid container spacing={2} sx={{ mt: 0, ml: '-10px' }}>
						{isLoading ? (
							<h3>Loading ...</h3>
						) : (
							data.map((item) => {
								return (
									<ArticlePreview
										key={item.id}
										isLabel={true}
										Icon={<BookmarkIcon />}
										{...item}
									/>
								)
							})
						)}
					</Grid>
				</Grid>
				<Grid item xs={4}>
					WIP
				</Grid>
			</Grid>
		</Container>
	)
}
