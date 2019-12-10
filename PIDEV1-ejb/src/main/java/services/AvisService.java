package services;

import java.io.Serializable;
import java.util.ArrayList;

import javax.ejb.LocalBean;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.persistence.TypedQuery;

import entites.Avis;


@Stateless
@LocalBean
public class AvisService implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	@PersistenceContext(unitName = "primary")
	EntityManager em;
	public void ajouterAvis(Avis p) {em.persist(p);}
	public void supprimer(int id )
	{
		Avis entity = new Avis();
		Query query =
				em.createQuery("SELECT e FROM Avis e WHERE e.avisId=:id  ",
						Avis.class);
				query.setParameter("id", id);
			entity=(Avis) query.getSingleResult();
		em.remove(entity);
	}
	public ArrayList<Avis> getAll()
	{ArrayList<Avis> p ;
	TypedQuery<Avis> query = em
			.createQuery("select c from Avis AS c", Avis.class);
	
		p = (ArrayList<Avis>) query.getResultList();
		return p;
}
	public float moy(int id)
	{   float z=0;
		ArrayList<Avis> p;
		TypedQuery<Avis> query = em
				.createQuery("select c from Avis c where c.entreprise.entrepriseId=:id ", Avis.class);
		query.setParameter("id", id);
			p = (ArrayList<Avis>) query.getResultList();
		for (Avis avis : p) { z= z+avis.getNote();
			
		}
		z=z/p.size();
		return z;
	}
}
