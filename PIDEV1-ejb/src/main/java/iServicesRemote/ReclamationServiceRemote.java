package iServicesRemote;

import javax.ejb.Remote;

import entites.Reclamation;

@Remote
public interface ReclamationServiceRemote {
	public void ajouterReclamation(Reclamation p);
	public void supprimer(int id );
}
